using Core.PoolSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPoolManager : MonoBehaviour
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
            IPool<T> newPool = createPool<T>();
            if(newPool is IPool<IPoolObject>)
            {
                throw new InvalidCastException(); // It must never work, cuz casting must always work because of method constraint
            }
            pools.Add(key, newPool as IPool<IPoolObject>);
            return (T)pools[key].GetInstance();
        }

        private IPool<T> createPool<T>() where T : IPoolObject
        {
            return new BasePool<T>(); // Default pool
        }

        private void Start()
        {
            Get<TestPoolObject>(); //TEST
            throw new Exception("YOU FORGOT TO CLEAN TEST CODE");
        }
    }
}
