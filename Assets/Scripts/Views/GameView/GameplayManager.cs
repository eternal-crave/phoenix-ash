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

namespace ViewSystem.Views.Gameplay
{
    public class GameplayManager
    {
        private event Action<int> OnScoreChange;

        private Player player;
        private PoolManager poolManager;
        private GameplayInput gameplayInput;
        private WeaponManager weaponManager;
        private GameFlow.GameFlow gameFlow;

        private bool gameIsRunning;
        private int score = 0;
        private int pointsForEnemyKill;
        private float enemyCreationInterval;
        private WeaponType defaultPlayerWeapon;
        private float creationOffsetFromEdges;

        public GameplayInput GameplayInput => gameplayInput;

        public Player GetPlayer()
        {
            return player;
        }

        public void SetInitialValues(int pointsForEnemyKill, float enemyCreationInterval, WeaponType defaultPlayerWeapon, float enemyBoxAreaOffset)
        {
            this.pointsForEnemyKill = pointsForEnemyKill;
            this.enemyCreationInterval = enemyCreationInterval;
            this.defaultPlayerWeapon = defaultPlayerWeapon;
            this.creationOffsetFromEdges = enemyBoxAreaOffset;
        }

        public GameplayManager(PoolManager poolManager, Player player, 
            GameplayInput gameplayInput, WeaponManager weaponManager, GameFlow.GameFlow gameFlow)
        {
            this.poolManager = poolManager;
            this.gameplayInput = gameplayInput;
            this.player = player;
            this.weaponManager = weaponManager;
            this.gameFlow = gameFlow;

            // Without unsubscribtion, cuz subsrcribtion happens only once
            gameFlow.OnGameStart += StartGame;
            gameFlow.OnEndGame += StopGame;
            gameFlow.OnWeaponChange += ChangeWeapon;
        }

        public void StartGame()
        {

            player.Init(gameplayInput);
            player.Activate();
            ChangeWeapon(defaultPlayerWeapon);
            gameIsRunning = true;
            StartEnemyCreation();
            OnScoreChange += gameFlow.OnScoreChange;

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
            OnScoreChange?.Invoke(score);
        }

        public void StopGame()
        {
            gameIsRunning = false;
            ((BasePool<Enemy>)poolManager.GetPool<Enemy>()).DeactivateAllInstances();
            OnScoreChange -= gameFlow.OnScoreChange;
        }


        // BAD solution
        public void ChangeWeapon(WeaponType type)
        {
            Weapon weapon;
            switch (type)
            {
                case WeaponType.SemiCirclce:
                    weapon = weaponManager.GetWeapon<SemiCircleWeapon>();
                    break;
                case WeaponType.Queue:
                    weapon = weaponManager.GetWeapon<QueueWeapon>();
                    break;
                default:
                    weapon = weaponManager.GetWeapon<SingleWeapon>();
                    break;
            }

            weapon.Init(poolManager.GetPool<Bullet>());
            player.SetWeapon(weapon);
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