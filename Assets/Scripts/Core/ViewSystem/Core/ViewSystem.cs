using Core.ViewSystem.Test.TestPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class ViewSystem : MonoBehaviour
    {
        [SerializeField] private static Transform instantiateContainer;

        public static P SetupView<P,V>() where P : Presenter, new() where V : View
        {
            V view = ((GameObject)Instantiate(Resources.Load(typeof(V).Name),instantiateContainer)).GetComponent<V>();
            P presenter = new P();
            return presenter;
        }


    }
}
