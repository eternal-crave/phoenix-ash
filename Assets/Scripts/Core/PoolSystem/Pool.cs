using System;
using System.Collections.Generic;

namespace Core.PoolSystem
{
    public abstract class Pool
    {
        private Queue<IPoolObject> pool;
        private List<IPoolObject> active;
        public abstract IPoolObject GetInstance();
    }
}
