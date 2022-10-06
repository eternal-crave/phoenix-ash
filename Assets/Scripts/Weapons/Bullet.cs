using Core.Factory;
using Core.PoolSystem;
using Core.UnitSystem;
using UnityEngine;

namespace Weapons
{
    public class Bullet : MonoBehaviour, IMakeDamage, IPoolObject, IFactoryItemPlaceHolder
    {
        public void Activate()
        {
            throw new System.NotImplementedException();
        }

        public void Deactivate()
        {
            throw new System.NotImplementedException();
        }

        public void MakeDamage(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}