using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class TestView : View, IActualTypeOfCouple<TestPresenter>
    {
        public TestPresenter GetActualTypeOfCouple()
        {
            return Presenter as TestPresenter;
        }

        private void Start()
        {
            Debug.Log($"From View::: This is my presenter:{Presenter}");
        }

    }
}