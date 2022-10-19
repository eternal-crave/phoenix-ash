using Core.SaveSystem.PlayerPrefsSaveSystem;
using Core.ViewSystem.Core;
using System;
using Units;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;
using Weapons;

namespace GameFlow
{
    public class GameFlow
    {
        public event Action<WeaponType> OnWeaponChange;

        private ViewManager viewManager;
        private Player player;
        private PPSaveSystem saveSystem;


        public event Action OnGameStart;
        public event  Action OnEndGame;



        public GameFlow(ViewManager viewManager, PPSaveSystem saveSystem, Player player)
        {
            this.viewManager = viewManager;
            this.saveSystem = saveSystem;  
            this.player = player;
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
            presenter.OnWeaponChange += OnWeaponChangeInput;
            presenter.Init(() =>
            {
                presenter.OnWeaponChange -= OnWeaponChangeInput;
                OpenGameOverScreen();
                OnEndGame?.Invoke();
            });
            OnGameStart.Invoke();
        }

        private void OnWeaponChangeInput(WeaponType obj)
        {
            OnWeaponChange?.Invoke(obj);
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
