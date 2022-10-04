using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public abstract class Presenter
    {
        private View view;

        public View View => view;
        public virtual void Init(Action onClose)
        {
            View.Init(onClose);
        }

        public Presenter(View view)
        {
            this.view = view;
        }
    }
}
