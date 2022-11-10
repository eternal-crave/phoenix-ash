using Core.PoolSystem;
using System;
using Random = UnityEngine.Random;
using System.Threading.Tasks;
using Units;
using UnityEngine;
using Core.SaveSystem.PlayerPrefsSaveSystem;
using GameConfiguration;
using Weapons;
using Core.ScoreSystem;

namespace ViewSystem.Views.Gameplay
{
    public class GameplayManager
    {
        

        private Player player;
        private PoolManager poolManager;
        private GameFlow.GameFlow gameFlow;
        private PPSaveSystem saveSystem;
        private GameConfig gameConfig;
        private WeaponManager weaponManager;
        private ScoreCounter scoreCounter;
        private bool gameIsRunning;

        
        public GameplayManager(PoolManager poolManager, Player player,
            GameFlow.GameFlow gameFlow, PPSaveSystem saveSystem, GameConfig gameConfig, WeaponManager weaponManager,
            ScoreCounter scoreCounter)
        {
            this.poolManager = poolManager;
            this.player = player;
            this.gameFlow = gameFlow;
            this.saveSystem = saveSystem;
            this.gameConfig = gameConfig;
            this.weaponManager = weaponManager;
            this.scoreCounter = scoreCounter;

            // Without unsubscribtion, cuz subsrcribtion happens only once
            // TODO rethink
            gameFlow.OnGameStart += StartGame;
            gameFlow.OnEndGame += StopGame;

        }

        public void StartGame()
        {
            player.Activate();
            weaponManager.Init(); // TODO test
            gameIsRunning = true;
            StartEnemyCreation();
        }

        public void StopGame()
        {
            gameIsRunning = false;
            SaveHighScore(scoreCounter.Score);
            scoreCounter.ResetScore();
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
                enemy.Init(GetEnemyCreationPoint(gameConfig.CreationOffsetFromEdges), player.transform.position);
                await Task.Delay(TimeSpan.FromSeconds(gameConfig.EnemyCreationInterval));
            }
        }

        private void AddScore()
        {
            scoreCounter.AddScore(gameConfig.PointsForEnemyKill);
            weaponManager.UnlockAvailableWeapons(scoreCounter.Score);
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