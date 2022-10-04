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
            OpenTestView();
        }

        private void OpenTestView()
        {
            TestPresenter presenter = viewManager.OpenView<TestView, TestPresenter>();
            presenter.Init(OpenTestView1);
        }

        private void OpenTestView1()
        {
            TestPresenter1 presenter = viewManager.OpenView<TestView1, TestPresenter1>();
            presenter.Init(() => Debug.Log("TEST VIEW HAS BEEN CLOSED"));
        }
    }
}
