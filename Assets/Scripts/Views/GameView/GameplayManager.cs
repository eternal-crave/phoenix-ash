using Core.PoolSystem;
using GameFlow.Managers;
using System;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Units;
using UnityEngine;
using Weapons;
using Zenject;
using GameplayLogicProcessor;
using Core.SaveSystem.PlayerPrefsSaveSystem;

namespace ViewSystem.Views.Gameplay
{
    public class GameplayManager
    {
        public event Action<int> OnScoreChange;

        private Player player;
        private PoolManager poolManager;
        private GameFlow.GameFlow gameFlow;
        private PPSaveSystem saveSystem;
        private bool gameIsRunning;

        // TODO rethink
        private int score = 0;
        private int pointsForEnemyKill;
        private float enemyCreationInterval;
        private float creationOffsetFromEdges;
        private GameplayProcessor gameplayProcessor;

        public void SetGamePlayProcessorLogic(GameplayProcessor gameplayProcessor)
        {
            this.gameplayProcessor = gameplayProcessor;
        }

        public void SetInitialValues(int pointsForEnemyKill, float enemyCreationInterval, WeaponType defaultPlayerWeapon, float enemyBoxAreaOffset)
        {
            this.pointsForEnemyKill = pointsForEnemyKill;
            this.enemyCreationInterval = enemyCreationInterval;
            //this.defaultPlayerWeapon = defaultPlayerWeapon;
            this.creationOffsetFromEdges = enemyBoxAreaOffset;
        }

        public GameplayManager(PoolManager poolManager, Player player,
            GameFlow.GameFlow gameFlow, PPSaveSystem saveSystem)
        {
            this.poolManager = poolManager;
            this.player = player;
            this.gameFlow = gameFlow;
            this.saveSystem = saveSystem;

            // Without unsubscribtion, cuz subsrcribtion happens only once
            // TODO rethink
            gameFlow.OnGameStart += StartGame;
            gameFlow.OnEndGame += StopGame;

        }

        

        public void StartGame()
        {
            player.Activate();
            gameIsRunning = true;
            StartEnemyCreation();
        }

        public void StopGame()
        {
            gameIsRunning = false;
            SaveHighScore(score);
            score = 0;
            ((BasePool<Enemy>)poolManager.GetPool<Enemy>()).DeactivateAllInstances();
        }

        private void SaveHighScore(int playerScore)
        {
            if (saveSystem.Load().Highscore >= playerScore)
            {
                return;
            }
            saveSystem.Save(new PPSaveSystemData() { Highscore = playerScore });
        }

        private async void StartEnemyCreation()
        {
            while (gameIsRunning)
            {
                Enemy enemy = poolManager.Get<Enemy>();
                enemy.OnDead += AddScore;
                enemy.Init(GetEnemyCreationPoint(creationOffsetFromEdges), player.transform.position);
                await Task.Delay(TimeSpan.FromSeconds(enemyCreationInterval));
            }
        }

        private void AddScore()
        {
            score += pointsForEnemyKill;
            gameplayProcessor.Check(score);
            OnScoreChange?.Invoke(score);
        }

        public void GetScoreInfo(out float currentScore, out float highScore)
        {
            currentScore = score;
            highScore = saveSystem.Load().Highscore;
        }


        private Vector3 GetRandomVector3Range(Vector3 minPosition, Vector3 maxPosition)
        {
            return new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
        }

        private Vector3 GetEnemyCreationPoint(float creationOffsetFromEdges)
        {
            Vector3 upperRight = new Vector3(Screen.width, Screen.height, 0);
            Vector3 lowerLeft = Vector3.zero;

            Vector3 horizontalMin = Camera.main.ScreenToWorldPoint(new Vector3(lowerLeft.x + creationOffsetFromEdges, upperRight.y / 2, 0));
            Vector3 horizontalMax = Camera.main.ScreenToWorldPoint(new Vector3(upperRight.x - creationOffsetFromEdges, upperRight.y / 2, 0));

            Vector3 verticalMin = Camera.main.ScreenToWorldPoint(new Vector3(((upperRight - lowerLeft) / 2).x, upperRight.y / 2, 0));
            Vector3 verticalMax = Camera.main.ScreenToWorldPoint(new Vector3(((upperRight - lowerLeft) / 2).x, upperRight.y - creationOffsetFromEdges, 0));

            return GetRandomVector3Range(GetRandomVector3Range(horizontalMin, horizontalMax),
                GetRandomVector3Range(verticalMin, verticalMax));

        }
    }
}