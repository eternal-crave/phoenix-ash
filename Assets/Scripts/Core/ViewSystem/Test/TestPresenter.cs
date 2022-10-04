using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class TestPresenter : Presenter, IActualTypeOfCouple<TestView>
    {
        public override event Action OnClose;

        public TestView GetActualTypeOfCouple()
        {
            return View as TestView;
        }

        public override void Init()
        {
            View.OnClose += OnClose;
            View.Init();
        }


        public TestPresenter(View view):base(view)
        {
            Debug.Log($"From Presenter::: This is my view:{View}");
        }
    }
}
