using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;

namespace ViewSystem.Presenters
{
    public class StartViewPresenter : Presenter, IActualTypeOfCouple<StartView>
    {

        public StartView GetActualTypeOfCouple()
        {
            return View as StartView;
        }

        public override void Init(Action onClose)
        {
            base.Init(onClose);
        }


        public StartViewPresenter(View view):base(view)
        {
            Debug.Log($"From Presenter::: This is my view:{View}");
        }
    }
}
