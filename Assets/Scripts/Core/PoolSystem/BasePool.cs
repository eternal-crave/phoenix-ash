using Core.PoolSystem;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Core.Factory;
using Weapons;

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
            Debug.Log("------------------------------------------------------------" +
                $"PASSIVE:{objectPool.Count} ------------ ACTIVE{activeObjectPool.Count}");
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

        protected override void InstertIntoPassivePool(IPoolObject obj)
        {
            int instanceIndex = activeObjectPool.FindIndex((o) => o.ID == obj.ID);
            if (instanceIndex >= 0)
            {
                objectPool.Enqueue((T)obj);
                activeObjectPool.RemoveAt(instanceIndex);
                Debug.Log($"PASSIVE:{objectPool.Count} ------------ ACTIVE{activeObjectPool.Count}");
            }
            else Debug.LogWarning("SOME SHIT HAPPENING WHEN TRYING TO INSERT FROM ACTIVE POOL TO PASSIVE POOL");
        }

        protected override T ExtractFromPassivePool() 
        {
            T instance = objectPool.Dequeue();
            activeObjectPool.Add(instance);
            instance.OnDeactivation += InstertIntoPassivePool;
            return instance;
        }
    }
}
