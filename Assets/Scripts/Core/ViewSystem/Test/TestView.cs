using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class TestView : View, IActualType<TestPresenter>
    {
        public TestPresenter GetActualType()
        {
            return Presenter as TestPresenter;
        }

      
    }
}