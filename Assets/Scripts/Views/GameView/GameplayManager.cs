using Core.PoolSystem;
using GameFlow.Managers;
using System;
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


        public GameplayInput GameplayInput => gameplayInput;

        public Player GetPlayer()
        {
            return player;
        }

        public void SetInitialValues(int pointsForEnemyKill, float enemyCreationInterval, WeaponType defaultPlayerWeapon)
        {
            this.pointsForEnemyKill = pointsForEnemyKill;
            this.enemyCreationInterval = enemyCreationInterval;
            this.defaultPlayerWeapon = defaultPlayerWeapon;
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
            ChangeWeapon(defaultPlayerWeapon); // default weapon
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
                enemy.Init(Vector3.zero, player.transform.position);
                await Task.Delay(TimeSpan.FromSeconds(enemyCreationInterval).Milliseconds);
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
    }
}