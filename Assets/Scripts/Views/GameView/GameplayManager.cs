using Core.PoolSystem;
using GameFlow.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Weapons;
using Zenject;

namespace ViewSystem.Views
{
    public class GameplayManager
    {
        private Player player;
        private PoolManager poolManager;
        private GameplayInput gameplayInput;
        private WeaponManager weaponManager;
        private GameFlow.GameFlow gameFlow;

        public GameplayInput GameplayInput => gameplayInput;

        public Player GetPlayer()
        {
            return player;
        }

        public GameplayManager(PoolManager poolManager, Player player, 
            GameplayInput gameplayInput, WeaponManager weaponManager, GameFlow.GameFlow gameFlow)
        {
            this.poolManager = poolManager;
            this.gameplayInput = gameplayInput;
            this.player = player;
            this.weaponManager = weaponManager;
            this.gameFlow = gameFlow;
            gameFlow.OnGameStart += StartGame;
            gameFlow.OnEndGame += StopGame;
            gameFlow.OnWeaponChange += ChangeWeapon;
        }

        public void StartGame()
        {
            player.Init(gameplayInput);
            player.Activate();
            ChangeWeapon(WeaponType.Single); // default weapon
        }

        public void StopGame()
        {
            gameFlow.OnGameStart -= StartGame;
            gameFlow.OnEndGame -= StopGame;
            gameFlow.OnWeaponChange -= ChangeWeapon;
            throw new NotImplementedException();
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