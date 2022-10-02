using Core.PoolSystem;
using UnityEngine;

namespace Core.PoolSystem
{
    public class BasePool<T> : IPool<T> where T : IPoolObject
    {
        public BasePool()
        {
            Debug.Log("THIS FUCKIN POOL HAS BEEN CREATED !!!!!!");
        }

        public override T GetInstance()
        {
            throw new System.NotImplementedException();
        }
    }
}
