using Core.PoolSystem;
using GameFlow.Managers;
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

        public GameplayInput GameplayInput => gameplayInput;

        private Player GetPlayer()
        {
            return player;
        }

        public GameplayManager(PoolManager poolManager, Player player, GameplayInput gameplayInput, WeaponManager weaponManager)
        {
            this.poolManager = poolManager;
            this.gameplayInput = gameplayInput;
            this.player = player;
            this.weaponManager = weaponManager;
            this.player.Init(gameplayInput);
            this.player.SetWeapon(this
                .weaponManager.GetWeapon<SingleWeapon>()
                .Init(poolManager.GetPool<Bullet>())); // FORTEST
        }
    }
}