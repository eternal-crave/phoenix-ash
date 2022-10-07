using Core.Factory;
using System;
using System.Collections.Generic;

namespace Core.PoolSystem
{
    public abstract class Pool<T> : IPool where T : IPoolObject, IFactoryItemPlaceHolder
    {
        public abstract int AmoutOfInitialCreations { get; }
        protected Queue<T> objectPool;
        protected List<T> activeObjectPool;
        protected Factory<T> factory;
        public abstract T GetObjectInstance();
        protected abstract void CreateObjectInstance();
        protected abstract void CreateMultipleObjectInstances(int count);
        protected abstract void InstertIntoPassivePool(T obj);
        protected abstract T ExtractFromPassivePool();

        public Pool(Factory<T> factory)
        {
            this.factory = factory;
        }

    }
}
