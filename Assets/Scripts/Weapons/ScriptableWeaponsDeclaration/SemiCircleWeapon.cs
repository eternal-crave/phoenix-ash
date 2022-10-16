using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SemiCircleWeapon", menuName = "Weapons/SemiCircleWeapon")]
    public class SemiCircleWeapon : Weapon
    {
        public override void Shoot(Vector2 origin, Vector2 direction)
        {
            throw new NotImplementedException();
        }
    }
}
