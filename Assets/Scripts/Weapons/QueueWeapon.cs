using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    public class QueueWeapon : Weapon
    {
        public QueueWeapon(PoolManager poolManager) : base(poolManager)
        {
        }

        public override void Shoot(Vector2 origin)
        {
            throw new NotImplementedException();
        }

        protected override Bullet GetAmmo()
        {
            throw new NotImplementedException();
        }
    }
}
