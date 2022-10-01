using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class ViewSystem : MonoBehaviour
    {
        [SerializeField] private Transform instantiateContainer;

        private void Start()
        {
            SetupView<TestPresenter, TestView>().Init();
        }
        public P SetupView<P,V>() where P : Presenter, new() where V : View
        {
            V view = ((GameObject)Instantiate(Resources.Load(typeof(V).Name),instantiateContainer)).GetComponent<V>();
            P presenter = new P();
            presenter.SetDependencies(view);
            return presenter;
        }
    }
}
