using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;
using TMPro;

namespace ViewSystem.Presenters
{
    public class GameOverViewPresenter : Presenter
    {
        private GameOverView view;

        public event Action OnRestartButtonClick;
        public event Action OnHomeButtonClick;

        

        public GameOverViewPresenter(View view) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
            this.view = (GameOverView)View;
        }
        public override void Init(Action onClose)
        {
            base.Init(onClose);
            SubscribeToEvents();
        }

        public void SetPlayerScores(int playerCurrentscore, int playerHighscore)
        {
            view.SetPlayerScores(playerCurrentscore, playerHighscore);
        }

        

        private void SubscribeToEvents()
        {
            view.OnRestartButtonClick += OnRestartButtonClicked;
            view.OnHomeButtonClick += OnHomeButtonClicked;
            view.OnClose += UnsubscribeToEvents;
        }

        private void UnsubscribeToEvents()
        {
            view.OnRestartButtonClick -= OnRestartButtonClicked;
            view.OnHomeButtonClick -= OnHomeButtonClicked;
            view.OnClose -= UnsubscribeToEvents;
        }

        private void OnHomeButtonClicked()
        {
            OnHomeButtonClick?.Invoke();
        }

        private void OnRestartButtonClicked()
        {
            OnRestartButtonClick?.Invoke();
        }
    }
}
