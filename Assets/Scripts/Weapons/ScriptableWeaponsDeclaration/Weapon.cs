using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : ScriptableObject
    {
        [SerializeField] protected WeaponType type;
        [SerializeField] protected float fireRate;
        [SerializeField] protected float bulletSpeed;
        protected float lastShootTime;
        protected Pool<Bullet> ammoPool;

        public WeaponType WeaponType => type;

        public abstract void Shoot(Vector3 origin, Quaternion rotation, Vector3 direction);
        protected virtual Bullet GetAmmo()
        {
            return ammoPool.GetObjectInstance();
        }
        public virtual Weapon Init(Pool<Bullet> ammoPool)
        {
            this.ammoPool = ammoPool;
            return this;
        }

        protected bool CanShoot()
        {
            if (Time.time < fireRate + lastShootTime)
            {
                return false;
            }
            lastShootTime = Time.time;
            return true;
        }

        private void OnDisable()
        {
            lastShootTime = 0;
        }


    }

    public enum WeaponType
    {
        Single,
        ShotGun,
        Queue,
    }
}
