using Core.PoolSystem;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Core.Factory;

namespace Core.PoolSystem
{

    public class BasePool<T> : Pool<T> where T : class, IPoolObject, IFactoryItemPlaceHolder
    {
        private int amoutOfInitialCreations = 1;
        public override int AmoutOfInitialCreations => amoutOfInitialCreations;
        public BasePool(Factory<T> factory) : base(factory)
        {
            objectPool = new Queue<T>();
            activeObjectPool = new List<T>();
        }

        

        public override T GetObjectInstance()
        {
            if(objectPool.Count == 0)
            {
                CreateMultipleObjectInstances(amoutOfInitialCreations);
            }
            return ExtractFromPassivePool();

        }

        protected override void CreateMultipleObjectInstances(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                CreateObjectInstance();
            }
        }

        protected override void CreateObjectInstance()
        {
            objectPool.Enqueue((T)factory.Create());
        }

        protected override void InstertIntoPassivePool(T obj)
        {
            int instanceIndex = activeObjectPool.FindIndex((o) => o.GetHashCode() == obj.GetHashCode());
            if (instanceIndex >= 0)
            {
                objectPool.Enqueue(obj);
                activeObjectPool.RemoveAt(instanceIndex);
            }
            else Debug.LogWarning("SOME SHIT HAPPENING WHEN TRYING TO INSERT FROM ACTIVE POOL TO PASSIVE POOL");
        }

        protected override T ExtractFromPassivePool()
        {
            T instance = objectPool.Dequeue();
            activeObjectPool.Add(instance);
            return instance;
        }
    }
}
