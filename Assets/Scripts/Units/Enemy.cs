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

namespace Units
{
    public class Enemy : Unit, IMakeDamage, IPoolObject, IFactoryItemPlaceHolder
    {
        public override event Action<float> OnGetDamage;
        public override event Action OnDead;

        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private float damage;
        [SerializeField] private float speed;


        public override float Health => health;
        public override float MaxHealth => maxHealth;

        protected void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Init(Vector3 position, Vector3 direction)
        {
            SetPosition(position);
            Activate();
            Move();
        }

        public override void GetDamage(float damage)
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

        private void Move()
        {
            StartCoroutine("moveCoroutine");
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
            //Unuse(); TODO imlement
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<IDeathZone>(out IDeathZone deathZone)) // if enters dead zone and took damage to player
            {

                MakeDamage(deathZone.GetDamageable(), damage);
                Deactivate();
            }
        }

        private IEnumerator moveEnumerator(Vector3 direction)
        {
            while (true)
            {
                gameObject.transform.position = Vector3.Lerp(transform.position, direction, speed * Time.deltaTime);
                yield return null;
            }
        }

        
    }
}
