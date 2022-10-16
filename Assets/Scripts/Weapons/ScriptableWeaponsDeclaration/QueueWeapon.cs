using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "QueueWeapon", menuName = "Weapons/QueueWeapon")]
    public class QueueWeapon : Weapon
    {
        public override void Shoot(Vector2 origin, Vector2 direction)
        {
            throw new NotImplementedException();
        }
    }
}
