using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class TestView : View, IActualTypeOfCouple<TestPresenter>
    {
        public override event Action OnClose;

        public TestPresenter GetActualTypeOfCouple()
        {
            return Presenter as TestPresenter;
        }

        public override void Init()
        {
            gameObject.SetActive(true);
            StartCoroutine("timer");
        }

        protected override void Close()
        {
            gameObject.SetActive(false);
            OnClose?.Invoke();

        }

        IEnumerator timer()
        {
            float time = 5;
            float offset = Time.time;
            while (time + offset > Time.time)
                yield return null;
            Close();
        }

    }
}