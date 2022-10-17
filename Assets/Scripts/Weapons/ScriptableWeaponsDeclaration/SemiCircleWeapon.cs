using Core.PoolSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "SemiCircleWeapon", menuName = "Weapons/SemiCircleWeapon")]
    public class SemiCircleWeapon : Weapon
    {
        [SerializeField] private float radius;
        [SerializeField] private int amountOfBullets;
        [SerializeField] private float offsetAngle;
        public override void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction)
        {
            //Fire rate
            if (!CanShoot())
            {
                return;
            }


            //Bullets setup to shoot to the FUCKIN LEPRIKONS
            foreach (Bullet bullet in PlaceBullets(origin, amountOfBullets, rotation.eulerAngles.z))
            {
                Vector3 relativePos = bullet.transform.position - origin;
                bullet.Activate();
                bullet.SetForce(relativePos + (bulletSpeed * direction));
            }
        }

        public List<Bullet> PlaceBullets(Vector3 origin, int amount, float rotationOffset)
        {
            Debug.Log(rotationOffset);
            List<Bullet> result = new List<Bullet>();
            float radianStep = (((225/*+rotationOffset*/) / amount)) * Mathf.PI / 180;
            //radianStep += offsetAngle * Mathf.PI / 180;
            for (int i = 1; i <= amount; i++)
            {
                float angle = i * radianStep;
                
                Bullet bullet = GetAmmo();
                bullet.transform.position = origin + new Vector3(Mathf.Cos(angle) * radius
                    , Mathf.Sin(angle) * radius, 0);
                result.Add(bullet);
            }

            return result;

        }
    }
}
