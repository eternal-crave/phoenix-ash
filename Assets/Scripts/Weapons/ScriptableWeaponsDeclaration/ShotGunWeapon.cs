using Core.PoolSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SemiCircleWeapon", menuName = "Weapons/SemiCircleWeapon")]
    public class ShotGunWeapon : Weapon
    {
        [SerializeField] private float step;
        [SerializeField] private int amountOfBullets;
        public override void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction)
        {
            //Fire rate
            if (!CanShoot())
            {
                return;
            }
            
            float dist = step * amountOfBullets;
            float offset = amountOfBullets % 2 == 1 ? 0 : (dist / (amountOfBullets - 1))/2;
            float amountOfInterations = amountOfBullets % 2 == 1 ? amountOfBullets/2+1 : amountOfBullets/2;
            for (int i = -amountOfBullets/2; i < amountOfInterations; i++)
            {
                float localStep = i*(dist / (amountOfBullets - 1)) + offset;
                Bullet bullet = GetAmmo();
                bullet.Activate();
                bullet.transform.position = new Vector3(origin.x + localStep, origin.y, 0);
                bullet.SetForce(bulletSpeed * direction);
            }
        }

        
    }
}
