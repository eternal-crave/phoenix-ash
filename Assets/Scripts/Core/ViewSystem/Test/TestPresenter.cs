using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.ViewSystem.Core
{
    public class TestPresenter : Presenter, IActualType<TestView>
    {
        public void Init()
        {
           
        }

        public TestView GetActualType()
        {
            return View as TestView;
        }
    }
}
