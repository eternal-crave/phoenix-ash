using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ViewSystem.Views
{
    public class StartView : View
    {
        [SerializeField] private Button tapToStartButton;

        public override void Init(Action onClose)
        {
            base.Init(onClose);
            tapToStartButton.onClick.AddListener(onTapToStartButtonPress);
            
        }

        private void onTapToStartButtonPress()
        {
            Close();
        }

        protected override void Close()
        {
            base.Close();
            tapToStartButton.onClick.RemoveAllListeners();
        }


    }
}