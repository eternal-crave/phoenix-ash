using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units;
using UnityEngine;
using Weapons;

namespace GameFlow.Managers
{
    public class WeaponManager
    {
        public Action<WeaponType> OnNewWeaponUnlock;
        public readonly WeaponType DefaultWeaponType;

        private string path = "Weapons";
        private List<Weapon> weapons;
        private PoolManager poolManager;
        private Player player;

        public WeaponManager(PoolManager poolmanager, Player player)
        {
            this.poolManager = poolmanager;
            this.player = player;
            weapons = new List<Weapon>();


            weapons.AddRange(Resources.LoadAll<Weapon>(path));
            weapons.ForEach(x => x.Init(poolManager.GetPool<Bullet>()));

            DefaultWeaponType = WeaponType.Single; // TODO HARDCODE change
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

        public void UnlockNecessaryWeapon()
        {
            // TODO logic
            OnNewWeaponUnlock?.Invoke(WeaponType.Single); // change
            throw new NotImplementedException();
        }
    }
}
