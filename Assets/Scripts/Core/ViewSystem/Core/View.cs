using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public abstract class View : MonoBehaviour 
    {
        private Presenter presenter;
        public Presenter Presenter => presenter;
        public void SetDependencies(Presenter presenter)
        {
            this.presenter = presenter; 
        }
    }
}