using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SingleWeapon", menuName = "Weapons/SingleWeapons")]
    public class SingleWeapon : Weapon
    {
       
        public override void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction)
        {
            //Fire rate
            if (!CanShoot())
            {
                return;
            }

            Bullet bullet = GetAmmo();
            bullet.Activate();
            bullet.transform.position = origin;
            bullet.SetForce(direction * bulletSpeed);
        }
    }
}
