using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public abstract class View : MonoBehaviour 
    {
        private Presenter presenter;
        public Presenter Presenter => presenter;
        public abstract void Init();

        [Inject]
        public void Construct(Presenter presenter)
        {
            this.presenter = presenter;
        }
    }
}