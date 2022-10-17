using Core.PoolSystem;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "QueueWeapon", menuName = "Weapons/QueueWeapon")]
    public class QueueWeapon : Weapon
    {
        [SerializeField] private int count;
        [SerializeField] private float intervalWithin = 0.4f;

        public override async void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction)
        {
            if (!CanShoot())
            {
                return;
            }

            await test(() =>
            {
                Bullet bullet = GetAmmo();
                bullet.Activate();
                bullet.transform.position = origin;
                bullet.SetForce(direction * bulletSpeed);
            });
        }

        private async Task test(Action callback)
        {
            for (int i = 0; i < count; i++)
            {
                callback?.Invoke();
                await Task.Delay(TimeSpan.FromSeconds(intervalWithin));
            }
        }

    }
}
