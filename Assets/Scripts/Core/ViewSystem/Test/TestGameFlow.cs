using Core.ViewSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.ViewSystem.Test
{
    public class TestGameFlow
    {
        private ViewManager viewManager;

        public TestGameFlow(ViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        public void StartGameFlow()
        {
            TestPresenter presenter = viewManager.OpenView<TestView, TestPresenter>();
            presenter.Init();
            presenter.OnClose += () => Debug.Log("TEST VIEW HAS BEEN CLOSED");
        }
    }
}
