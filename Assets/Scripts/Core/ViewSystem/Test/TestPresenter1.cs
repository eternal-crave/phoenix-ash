using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class TestPresenter1 : Presenter, IActualTypeOfCouple<TestView1>
    {

        public TestView1 GetActualTypeOfCouple()
        {
            return View as TestView1;
        }

        public override void Init(Action onClose)
        {
            View.Init(onClose);
        }


        public TestPresenter1(View view):base(view)
        {
            Debug.Log($"From Presenter::: This is my view:{View}");
        }
    }
}
