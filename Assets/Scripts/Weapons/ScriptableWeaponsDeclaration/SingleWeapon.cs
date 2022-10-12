using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SingleWeapon", menuName = "Weapons/SingleWeapons")]
    public class SingleWeapon : Weapon
    {

        public override void Shoot(Vector2 origin)
        {
            Bullet bullet = GetAmmo();
            bullet.transform.position = origin;
            bullet.SetForce(Vector2.up * bulletSpeed);
        }

        protected override Bullet GetAmmo()
        {
            return null;
        }
    }
}
