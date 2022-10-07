using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.UnitSystem
{
    public abstract class Unit : MonoBehaviour, IGetDamage
    {
        public abstract event Action<float> OnGetDamage;
        public abstract event Action OnDead;
        public abstract float Health { get; }
        public abstract float MaxHealth { get; }
        public abstract void GetDamage(float damage);
    }
}