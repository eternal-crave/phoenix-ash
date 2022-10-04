using System;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public abstract class View : MonoBehaviour 
    {
        public abstract event Action OnClose;
        public abstract void Init();
        protected abstract void Close();

    }
}