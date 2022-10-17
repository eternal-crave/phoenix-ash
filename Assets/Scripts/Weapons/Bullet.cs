using Core.Factory;
using Core.PoolSystem;
using Core.UnitSystem;
using System;
using Units;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour, IMakeDamage, IPoolObject, IFactoryItemPlaceHolder
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float damage = 1;

        public int ID => GetInstanceID();

        public event Action<IPoolObject> OnDeactivation;

        public void SetForce(Vector2 dir)
        {
            rb.AddForce(dir, ForceMode2D.Impulse);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            OnDeactivation?.Invoke(this);
            OnDeactivation = null;
        }

        public void MakeDamage(IGetDamage damageable, float damage)
        {
            damageable.GetDamage(damage);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            /*if(other.TryGetComponent(out Enemy enemy))
            {
                MakeDamage(enemy, damage);
                Deactivate();
            }*/
        }

        private void OnBecameInvisible()
        {
            Deactivate();
        }
    }
}