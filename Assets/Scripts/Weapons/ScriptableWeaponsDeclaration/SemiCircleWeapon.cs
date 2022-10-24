using Core.PoolSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SemiCircleWeapon", menuName = "Weapons/SemiCircleWeapon")]
    public class SemiCircleWeapon : Weapon
    {
        [SerializeField] private float offset;
        [SerializeField] private float step;
        [SerializeField] private int amountOfBullets;
        public override void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction)
        {
            //Fire rate
            if (!CanShoot())
            {
                return;
            }


            for(int i = -(amountOfBullets/2); i < amountOfBullets/2; i++)
            {
                float localStep = i * step;
                Bullet bullet = GetAmmo();
                bullet.Activate();
                bullet.transform.position = new Vector3(origin.x + localStep, origin.y, 0);
                bullet.SetForce(bulletSpeed * direction);
            }
        }

        
    }
}
