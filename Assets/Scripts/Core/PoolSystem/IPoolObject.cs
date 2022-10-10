using System;

namespace Core.PoolSystem
{
    public interface IPoolObject
    {
        event Action<IPoolObject> OnDeactivation;
        public void Activate();
        public void Deactivate();
    }
}
