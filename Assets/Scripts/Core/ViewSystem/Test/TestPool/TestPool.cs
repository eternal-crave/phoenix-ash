using Core.PoolSystem;
using System;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPool : BasePool<TestPoolObject>
    {
        public override TestPoolObject GetInstance()
        {
            throw new NotImplementedException();
        }
    }
}
