using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    public class SingleWeapon : Weapon
    {
        public SingleWeapon(PoolManager poolManager) : base(poolManager)
        {
        }

        public override void Shoot(Vector2 origin)
        {
            GetAmmo().transform.position = origin;
            throw new NotImplementedException();
        }

        protected override Bullet GetAmmo()
        {
            return poolManager.Get<Bullet>();
        }
    }
}
