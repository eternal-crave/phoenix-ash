using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UnitSystem
{
    public abstract class Unit : MonoBehaviour, IMakeDamage, IGetDamage
    {
        public abstract event Action<int> OnGetDamage;
        public abstract float Health { get; }
        public abstract float MaxHealth { get; }
        public abstract void GetDamage(float damage);
        public abstract void MakeDamage(float damage);
    }
}