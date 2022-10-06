using Core.UnitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Units
{
    public class Enemy : Unit
    {
        [SerializeField] private float health;
        [SerializeField] private float maxHealth;
        public override float Health => health;
        public override float MaxHealth => maxHealth;

        public override event Action<int> OnGetDamage;

        public override void GetDamage(float damage)
        {
            throw new NotImplementedException();
        }

        public override void MakeDamage(float damage)
        {
            throw new NotImplementedException();
        }

        private void Move()
        {

        }

        public void Init()
        {

        }
    }
}
