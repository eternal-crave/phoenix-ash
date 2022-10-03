using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class TestPresenter : Presenter, IActualTypeOfCouple<TestView>
    {
        public void Greet()
        {
            Debug.Log($"From Presenter::: This is my view:{View}");
        }

        public TestView GetActualTypeOfCouple()
        {
            return View as TestView;
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}
