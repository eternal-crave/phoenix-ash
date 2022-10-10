using Core.Factory;
using System;
using System.Collections.Generic;
using Zenject;

namespace Core.PoolSystem
{
    public abstract class Pool<T> : IPool where T : IPoolObject, IFactoryItemPlaceHolder
    {
        public abstract int AmoutOfInitialCreations { get; }
        protected Queue<T> objectPool;
        protected List<T> activeObjectPool;
        protected Core.Factory.Factory<T> factory;
        public abstract T GetObjectInstance();
        protected abstract void CreateObjectInstance();
        protected abstract void CreateMultipleObjectInstances(int count);
        protected abstract void InstertIntoPassivePool(IPoolObject obj);
        protected abstract T ExtractFromPassivePool();

        [Inject]
        public Pool(Core.Factory.Factory<T> factory)
        {
            this.factory = factory;
        }

    }
}
