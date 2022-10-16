using Core.PoolSystem;
using System;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SingleWeapon", menuName = "Weapons/SingleWeapons")]
    public class SingleWeapon : Weapon
    {
       
        public override void Shoot(Vector2 origin, Vector2 direction)
        {
            if (Time.time < FireRate + lastShootTime)
            {
                return;
            }
            Debug.Log("Single Shot");
            lastShootTime = Time.time;
            Bullet bullet = GetAmmo();
            bullet.transform.position = origin;
            bullet.SetForce(direction * bulletSpeed);
        }
    }
}
