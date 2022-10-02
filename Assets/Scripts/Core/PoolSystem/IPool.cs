using System;
using System.Collections.Generic;

namespace Core.PoolSystem
{
    public abstract class IPool<T> where T : IPoolObject
    {
        private Queue<T> pool;
        private List<T> active;
        public abstract T GetInstance();
    }
}
