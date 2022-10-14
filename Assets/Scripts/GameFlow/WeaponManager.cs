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

        public WeaponManager()
        {
            weapons = new List<Weapon>();
            weapons.ForEach(x => x.Init(poolManager.GetPool<Bullet>()));
            weapons.AddRange(Resources.LoadAll<Weapon>(path));
        }

        public W GetWeapon<W>() where W : Weapon
        {
            return (W)weapons.FirstOrDefault(w => w.GetType() == typeof(W));
        }
    }
}
