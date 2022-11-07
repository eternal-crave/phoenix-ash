using Core.PoolSystem;
using Core.UnitSystem;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Core.Factory;
using Units.DeathZone;

namespace Units
{
    public class Enemy : Unit, IGetDamage, IMakeDamage, IPoolObject, IFactoryItemPlaceHolder
    {
        public event Action<float> OnGetDamage;
        public event Action OnDead;
        public event Action<IPoolObject> OnDeactivation;

        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private float damage;
        [SerializeField] private float speed;


        public float Health => health;
        public float MaxHealth => maxHealth;

        public int ID => GetInstanceID();

        protected void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Init(Vector3 position, Vector3 targetPos)
        {
            SetPosition(position);
            Activate();
            Move(targetPos);
        }

        public void GetDamage(float damage)
        {
            if(health > damage)
            {
                health -= damage;
                OnGetDamage?.Invoke(damage);
                return;
            }
            OnDead?.Invoke();
            Deactivate();
        }

        public void MakeDamage(IGetDamage damageable, float damage)
        {
            damageable.GetDamage(damage);
        }

        private void Move(Vector3 targetPos)
        {
            StartCoroutine("moveEnumerator", targetPos);
        }
        public void Activate()
        {
            health = maxHealth;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            StopAllCoroutines();
            OnDead = null;
            gameObject.SetActive(false);
            OnDeactivation?.Invoke(this);
            OnDeactivation = null;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out IDeathZone deathZone)) // if enters dead zone and took damage to player
            {
                MakeDamage(deathZone.GetDamageable(), damage);
                Deactivate();
            }
        }

        private IEnumerator moveEnumerator(Vector3 targetPos)
        {
            while (true)
            {
                gameObject.transform.position = Vector3.Lerp(transform.position, targetPos, speed/100 * Time.deltaTime);
                yield return null;
            }
        }

        
    }
}
