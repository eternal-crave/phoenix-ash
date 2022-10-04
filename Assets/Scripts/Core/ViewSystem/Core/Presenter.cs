using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public abstract class Presenter
    {
        public abstract event Action OnClose;
        private View view;

        public View View => view;
        public abstract void Init();

        public Presenter(View view)
        {
            this.view = view;
        }
    }
}
