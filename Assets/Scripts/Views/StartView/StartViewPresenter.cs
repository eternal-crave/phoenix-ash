using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;
using Core.SaveSystem.PlayerPrefsSaveSystem;

namespace ViewSystem.Presenters
{
    public class StartViewPresenter : Presenter
    {
        private PPSaveSystem saveSystem;
        public StartViewPresenter(View view, PPSaveSystem saveSystem) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
            this.saveSystem = saveSystem;
        }
      
        public override void Init(Action onClose)
        {
            base.Init(onClose);
            ((StartView)View).SetHighScoreText(GetHighScore());
        }

        private int GetHighScore()
        {
            return saveSystem.Load().Highscore;
        }
    }
}
