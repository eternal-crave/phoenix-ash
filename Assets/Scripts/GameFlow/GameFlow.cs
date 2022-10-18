using Core.SaveSystem.PlayerPrefsSaveSystem;
using Core.ViewSystem.Core;
using System;
using Units;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;

namespace GameFlow
{
    public class GameFlow
    {
        private ViewManager viewManager;
        private Player player;
        private PPSaveSystem saveSystem;
        private GameplayManager gameplayManager;

        public event Action OnGameStart;

        public GameFlow(ViewManager viewManager, PPSaveSystem saveSystem, GameplayManager gameplayManager)
        {
            this.viewManager = viewManager;
            this.saveSystem = saveSystem;   
            this.gameplayManager = gameplayManager;
            player = gameplayManager.GetPlayer();
        }

        public void StartGameFlow()
        {
            OpenStartView();
        }

        private void OpenStartView()
        {
            StartViewPresenter presenter = viewManager.OpenView<StartView, StartViewPresenter>();
            presenter.SetHighScore((int)LoadHighScore());
            presenter.Init(OpenGameView);
        }

        private void OpenGameView()
        {
            GameViewPresenter presenter = viewManager.OpenView<GameView, GameViewPresenter>();
            presenter.SetValues((int)player.Health, 0);
            player.OnGetDamage += presenter.OnPlayerGetDamage;
            player.OnDead += presenter.OnPlayerDead;
            presenter.Init(OpenGameOverScreen);
        }

        private void OpenGameOverScreen()
        {
            GameOverViewPresenter presenter = viewManager.OpenView<GameOverView, GameOverViewPresenter>();
            presenter?.Init(null);
        }

        private float LoadHighScore()
        {
            return saveSystem.Load().Highscore;
        }
    }
}
