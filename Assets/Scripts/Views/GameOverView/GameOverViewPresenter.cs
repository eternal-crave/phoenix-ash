using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;

namespace ViewSystem.Presenters
{
    public class GameOverViewPresenter : Presenter
    {
        public GameOverViewPresenter(View view) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
        }
        public override void Init(Action onClose)
        {
            base.Init(onClose);
        }
    }
}
