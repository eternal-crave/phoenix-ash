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

        public void SetDependencies(View view)
        {
            this.view = view;
            view.SetDependencies(this);
        }
    }
}
