using Core.Factory;
using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.PoolSystem
{
    public class PoolManager : MonoBehaviour
    {
        private Dictionary<Type, Pool<IPoolObject>> pools = new Dictionary<Type, Pool<IPoolObject>>();
        private FactoryManager factoryManager;

        [Inject]
        private void Construct(FactoryManager factoryManager) 
        {
            this.factoryManager = factoryManager;
        }
        public T Get<T>() where T : class, IPoolObject, IFactoryItemPlaceHolder
        {
            Type key = typeof(T);
            if (pools.ContainsKey(key))
            {
                return (T)pools[key].GetObjectInstance();

            }
            Pool<T> newPool = createPool<T>();
            if (!(newPool is Pool<IPoolObject>))
            {
                throw new InvalidCastException(); // It must never work, cuz casting must always work because of method constraint
            }
            pools.Add(key, newPool as Pool<IPoolObject>);
            return (T)pools[key].GetObjectInstance();
        }

        private Pool<T> createPool<T>() where T : class, IPoolObject, IFactoryItemPlaceHolder
        {
            return new BasePool<T>(factoryManager.GetFactory<T>()); // Default pool
        }
    }
}
