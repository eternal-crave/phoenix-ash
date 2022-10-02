using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPoolManager
    {
        private Dictionary<Type, IPool<IPoolObject>> pools = new Dictionary<Type, IPool<IPoolObject>>();
        
        public T Get<T>() where T : IPoolObject
        {
            Type key = typeof(T);
            if (pools.ContainsKey(key))
            {
                T pool = (T)pools[key].GetInstance();
                pools.Remove(key);
                return pool;

            }

            pools.Add(key, createPool<IPool<IPoolObject>>());
            return (T)pools[key].GetInstance();
        }

        private T createPool<T>() where T : IPool<IPoolObject>
        {
           return Activator.CreateInstance<T>();    
        }



        
    }
}
