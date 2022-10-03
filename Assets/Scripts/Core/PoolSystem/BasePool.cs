using Core.PoolSystem;
using UnityEngine;
using System.Collections.Generic;

namespace Core.PoolSystem
{

    public class BasePool<T> : Pool<T> where T : class, IPoolObject
    {
        [SerializeField] private int amoutOfInitialCreations = 1;
        public override int AmoutOfInitialCreations => amoutOfInitialCreations;
        public BasePool()
        {
            Debug.Log("THIS FUCKIN POOL HAS BEEN CREATED !!!!!!");
            objectPool = new Queue<T>();
            activeObjectPool = new List<T>();
        }

        

        public override T GetObjectInstance()
        {
            if(objectPool.Count == 0)
            {
                CreateMultipleObjectInstances();
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
            // Call factory
            throw new System.NotImplementedException();
        }
    }
}
