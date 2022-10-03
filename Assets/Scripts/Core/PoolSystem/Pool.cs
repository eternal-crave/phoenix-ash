using System;
using System.Collections.Generic;

namespace Core.PoolSystem
{
    public abstract class Pool<T> where T : IPoolObject
    {
        public abstract int AmoutOfInitialCreations { get; }
        protected Queue<T> objectPool;
        protected List<T> activeObjectPool;
        public abstract T GetObjectInstance();
        protected abstract void CreateObjectInstance();
        protected abstract void CreateMultipleObjectInstances(int count);
        protected virtual void InstertIntoPassivePool(T obj)
        {
            throw new NotImplementedException();
        }
        protected virtual T ExtractFromPassivePool()
        {
            throw new NotImplementedException();
        }

    }
}
