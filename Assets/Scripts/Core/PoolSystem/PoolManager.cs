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
        private Dictionary<Type, IPool> pools = new Dictionary<Type, IPool>();
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
                return ((Pool<T>)pools[key]).GetObjectInstance();
            }
            Pool<T> newPool = (Pool<T>)createPool<T>();
            pools.Add(key, newPool);
            return ((Pool<T>)pools[key]).GetObjectInstance();
        }

        private IPool createPool<T>() where T : class, IPoolObject, IFactoryItemPlaceHolder
        {
            return new BasePool<T>(factoryManager.GetFactory<T>()); // Default pool
        }
    }
}
