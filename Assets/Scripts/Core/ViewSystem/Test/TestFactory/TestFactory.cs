using Core.ViewSystem.Core;
using System;
using Zenject;
using UnityEngine;

namespace Core.ViewSystem.Test.TestFactory
{
    public static class TestFactory
    {
        public static void GetInstanceDI(DiContainer container)
        {

        }

        public static TType GetInstanceGameObjectAsSingle<TType>(this DiContainer diContainer, Type type, Transform container) where TType : MonoBehaviour
        {
            var obj = diContainer.InstantiatePrefabResourceForComponent<TType>(type.Name, container);
            diContainer.BindInstance(obj).AsSingle();
            return obj;

        }
    }
}
