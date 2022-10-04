using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ViewSystem.Core
{
    public class TestView : View
    {
        public override event Action OnClose;


        public override void Init(Action onClose)
        {
            OnClose = onClose;
            gameObject.SetActive(true);
            StartCoroutine("timer");
        }

        protected override void Close()
        {
            OnClose?.Invoke();
            OnClose = null;
            gameObject.SetActive(false);
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