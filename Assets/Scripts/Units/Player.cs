using Core.UnitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using ViewSystem.Views;
using Weapons;
using Zenject;

namespace Units
{
    public class Player : Unit
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private Transform bulletSpawnPoint;
        private GameplayInput gameplayInput;
        private Weapon weapon;


        public override event Action<float> OnGetDamage;
        public override event Action OnDead;

        public override float Health => health;
        public override float MaxHealth => maxHealth;

        public override void GetDamage(float damage)
        {
            if (health > damage)
            {
                health -= damage;
                OnGetDamage?.Invoke(damage);
                return;
            }
            OnDead?.Invoke();
            Deactivate();
        }

        public void Init(GameplayInput gameplayInput)
        {
            this.gameplayInput = gameplayInput;
        }

        public void SetWeapon(Weapon weapon)
        {
            this.weapon = weapon;
            Debug.Log(weapon.GetType());
        }

        private void OnUserInputHandler(Vector3 position)
        {
            Move(position);
        }

        private void Move(Vector3 position)
        {

            Vector3 myLocation = transform.position;
            Vector3 targetLocation = position;
            Vector3 vectorToTarget = targetLocation - myLocation;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, vectorToTarget);
            transform.rotation = targetRotation;
        }

        private void Attack(Vector2 lookDirection)
        {
            weapon.Shoot(bulletSpawnPoint.transform.position, transform.rotation, lookDirection);
        }

        private void OnEnable()
        {
            gameplayInput.OnPlayerInput += OnUserInputHandler;
        }

        private void OnDisable()
        {
            gameplayInput.OnPlayerInput -= OnUserInputHandler;
            OnGetDamage = null;
            OnDead = null;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        private void ResetHealth()
        {
            health = maxHealth;
        }
        
        private void Deactivate()
        {
            gameObject.SetActive(false);
            ResetHealth();
        }

        private void Update()
        {
            Vector2 lookDirection = bulletSpawnPoint.transform.position- transform.position;
            RaycastHit2D hit = Physics2D.Raycast(bulletSpawnPoint.position, lookDirection,float.MaxValue);
            Debug.DrawRay(bulletSpawnPoint.position, lookDirection, Color.red); //TODO DELETE AFTER
            if (hit.collider != null && hit.transform.TryGetComponent(out Unit enemy))
            {
                Attack(lookDirection);
            }
        }
    }
}
