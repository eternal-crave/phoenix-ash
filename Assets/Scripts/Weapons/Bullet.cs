using Core.Factory;
using Core.PoolSystem;
using Core.UnitSystem;
using Units;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour, IMakeDamage, IPoolObject, IFactoryItemPlaceHolder
    {
        [SerializeField] private float damage = 1;
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(true);
            // Unuse() TODO implement
        }

        public void MakeDamage(IGetDamage damageable, float damage)
        {
            damageable.GetDamage(damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Enemy enemy))
            {
                MakeDamage(enemy, damage);
                Deactivate();
            }
        }

        private void OnBecameInvisible()
        {
            Deactivate();
        }
    }
}