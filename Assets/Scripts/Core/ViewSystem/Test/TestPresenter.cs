using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class TestPresenter : Presenter, IActualTypeOfCouple<TestView>
    {

        public TestView GetActualTypeOfCouple()
        {
            return View as TestView;
        }

        public override void Init(Action onClose)
        {
            View.Init(onClose);
        }


        public TestPresenter(View view):base(view)
        {
            Debug.Log($"From Presenter::: This is my view:{View}");
        }
    }
}
