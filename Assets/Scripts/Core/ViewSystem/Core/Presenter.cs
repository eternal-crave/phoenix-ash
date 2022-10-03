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
        public abstract void Init();

        [Inject]
        public void Construct(View view)
        {
            this.view = view;
        }
    }
}
