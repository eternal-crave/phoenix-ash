using Core.PoolSystem;
using System;
using UnityEngine;

namespace Core.ViewSystem.Test.TestPool
{
    public class TestPool : IPool
    {
        public IPoolObject PoolObject { get; private set; }
    }
}
