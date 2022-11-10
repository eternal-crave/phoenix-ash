using Core.PoolSystem;
using GameConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using Units;
using UnityEngine;

namespace Weapons
{
    public class WeaponManager
    {
        public Action<WeaponType> OnNewWeaponUnlock;

        private Dictionary<WeaponType, bool> weaponAccessability;
        private string path = "Weapons";
        private List<Weapon> weapons;
        private PoolManager poolManager;
        private Player player;
        private GameConfig gameConfig;

        public WeaponType DefaultWeaponType => gameConfig.DefaultPlayerWeapon;

        public WeaponManager(PoolManager poolManager, Player player, GameConfig gameConfig)
        {
            this.poolManager = poolManager;
            this.player = player;
            this.gameConfig = gameConfig;

            weapons = new List<Weapon>();
            weaponAccessability = new Dictionary<WeaponType, bool>();
            weapons.AddRange(Resources.LoadAll<Weapon>(path));
            weapons.ForEach(w =>
            {
                w.Init(poolManager.GetPool<Bullet>());
                weaponAccessability[w.WeaponType] = false;
            });
        }

        public void Init()
        {
            EquipDefaultWeapon();
        }

        public W GetWeapon<W>() where W : Weapon
        {
            return (W)weapons.FirstOrDefault(w => w.GetType() == typeof(W));
        }

        // BAD solution
        public void ChangeWeapon(WeaponType type)
        {
            Weapon weapon;
            switch (type)
            {
                case WeaponType.ShotGun:
                    weapon = GetWeapon<ShotGunWeapon>();
                    break;
                case WeaponType.Queue:
                    weapon = GetWeapon<QueueWeapon>();
                    break;
                default:
                    weapon = GetWeapon<SingleWeapon>();
                    break;
            }

            weapon.Init(poolManager.GetPool<Bullet>());
            player.SetWeapon(weapon);
        }

        public void EquipDefaultWeapon()
        {
            weaponAccessability[DefaultWeaponType] = true;
            ChangeWeapon(DefaultWeaponType);
        }

        public void UnlockAvailableWeapons(float score)
        {
            foreach(var weaponType in weaponAccessability.Keys)
            {
                if (weaponType == DefaultWeaponType) continue;

                if (!weaponAccessability[weaponType] && score >= gameConfig.WeaponPointsPair[weaponType])
                {
                    UnlockWeapon(weaponType);
                    OnNewWeaponUnlock?.Invoke(weaponType);
                    break;
                }
            }
        }

        private void UnlockWeapon(WeaponType weaponType)
        {
            weaponAccessability[weaponType] = true;
        }
    }
}
