using Core.PoolSystem;
using System;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPool : Pool
    {

        public override IPoolObject GetInstance()
        {
            return null;
        }
    }
}
