using Core.UnitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using ViewSystem.Views;

namespace Units
{
    public class Player : Unit
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        [SerializeField] private float speed;
        private GameplayInput gameplayInput;


        public override event Action<int> OnGetDamage;
        public override float Health => health;
        public override float MaxHealth => maxHealth;


        private void Construct(GameplayInput input)
        {
            this.gameplayInput = input;
        }


        public override void GetDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public override void MakeDamage(float damage)
        {
            throw new NotImplementedException();
        }

        private void OnUserInputHandler(Vector3 position)
        {
            Move(position);
        }

        private void Move(Vector3 position)
        {
            transform.rotation = Quaternion.LookRotation(position);
        }

        private void OnEnable()
        {
            gameplayInput.OnPlayerInput += OnUserInputHandler;
        }

        private void OnDisable()
        {
            gameplayInput.OnPlayerInput -= OnUserInputHandler;
        }
    }
}
