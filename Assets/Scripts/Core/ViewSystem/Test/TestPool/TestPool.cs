using Core.Factory;
using Core.PoolSystem;
using System;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPool : BasePool<TestPoolObject>
    {
        public TestPool(Factory<IFactoryItemPlaceHolder> factory) : base(factory)
        {
        }

        public override TestPoolObject GetObjectInstance()
        {
            throw new NotImplementedException();
        }
    }
}
