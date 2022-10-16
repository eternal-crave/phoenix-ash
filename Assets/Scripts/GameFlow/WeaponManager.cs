using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Weapons;

namespace GameFlow.Managers
{
    public class WeaponManager
    {
        private string path = "Weapons";
        private List<Weapon> weapons;
        private PoolManager poolManager;

        public WeaponManager(PoolManager poolmanager)
        {
            this.poolManager = poolmanager;
            weapons = new List<Weapon>();


            weapons.AddRange(Resources.LoadAll<Weapon>(path));
            weapons.ForEach(x => x.Init(poolManager.GetPool<Bullet>()));
        }

        public W GetWeapon<W>() where W : Weapon
        {
            return (W)weapons.FirstOrDefault(w => w.GetType() == typeof(W));
        }
    }
}
