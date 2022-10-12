using Core.PoolSystem;
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
        [SerializeField] protected float ShootRateMilliseconds;
        [SerializeField] protected float bulletSpeed;
        [SerializeField] protected float damage;
        protected PoolManager poolManager;

        public abstract void Shoot(Vector2 origin);
        protected abstract Bullet GetAmmo();

        /*public Weapon(PoolManager poolManager)
        {
            this.poolManager = poolManager; // Figure out how to inject pool manager
        }*/
    }

    public enum WeaponType
    {
        Single,
        SemiCirclce,
        Queue,
    }
}
