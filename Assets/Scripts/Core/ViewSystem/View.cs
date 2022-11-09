using System;
using UnityEngine;

namespace Core.ViewSystem
{
    public abstract class View : MonoBehaviour
    {
        public virtual event Action OnClose;
        public virtual void Init(Action onClose)
        {
            Activate();
            OnClose = onClose;
        }
        protected virtual void Close()
        {
            OnClose?.Invoke();
            OnClose = null;
            gameObject.SetActive(false);
        }
        protected virtual void Activate()
        {
            gameObject.SetActive(true);
        }

    }
}