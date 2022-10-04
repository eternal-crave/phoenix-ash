using System;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public abstract class View : MonoBehaviour 
    {
        public abstract event Action OnClose;
        private Presenter presenter;
        public Presenter Presenter => presenter;
        public abstract void Init();
        protected abstract void Close();

    }
}