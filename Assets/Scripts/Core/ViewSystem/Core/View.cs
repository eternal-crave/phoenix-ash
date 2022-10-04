using System;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public abstract class View : MonoBehaviour 
    {
        public abstract event Action OnClose;
        public abstract void Init(Action onClose);
        protected abstract void Close();

    }
}