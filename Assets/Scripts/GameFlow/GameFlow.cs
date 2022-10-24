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
        public event Action<WeaponType> OnWeaponGain;

        private ViewManager viewManager;
        private Player player;
        private PPSaveSystem saveSystem;
        
        private int playerHighscore;
        private int playerCurrentscore;
        private WeaponType defaultPlayerWeapon;

        public event Action OnGameStart;
        public event Action OnEndGame;
        public event Action<int> OnPlayerScoreChange;



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
            playerHighscore = LoadHighScore();
            presenter.SetHighScore(playerHighscore);
            presenter.Init(OpenGameView);
        }

        private void OpenGameView()
        {
            GameViewPresenter presenter = viewManager.OpenView<GameView, GameViewPresenter>();
            presenter.SetValues((int)player.Health, 0);
            presenter.ResetWeapons(defaultPlayerWeapon);
            player.OnGetDamage += presenter.OnPlayerGetDamage;
            player.OnDead += presenter.OnPlayerDead;
            presenter.OnWeaponChange += OnWeaponChangeInput;
            OnPlayerScoreChange += presenter.SetScore;
            OnWeaponGain += presenter.UnlockWeapon;
            presenter.Init(() =>
            {
                presenter.OnWeaponChange -= OnWeaponChangeInput;
                OnPlayerScoreChange -= presenter.SetScore;
                OnWeaponGain -= presenter.UnlockWeapon;
                SaveHighScore(presenter.PlayerScore);
                OpenGameOverScreen();
                OnEndGame?.Invoke();
            });
            OnGameStart.Invoke();
        }

        private void OpenGameOverScreen()
        {
            GameOverViewPresenter presenter = viewManager.OpenView<GameOverView, GameOverViewPresenter>();
            presenter.SetPlayerScores(playerCurrentscore, playerHighscore);
            presenter.OnRestartButtonClick += OpenGameView;
            presenter.OnHomeButtonClick += OpenStartView;
            presenter?.Init(() =>
            {
                presenter.OnRestartButtonClick -= OpenGameView;
                presenter.OnHomeButtonClick -= OpenStartView;
            });
        }

        public void SetDeafultWeapon(WeaponType defaultPlayerWeapon)
        {
            this.defaultPlayerWeapon = defaultPlayerWeapon;
        }

        public void GainWeapon(WeaponType weaponType)
        {
            OnWeaponGain?.Invoke(weaponType);
        }

        private void OnWeaponChangeInput(WeaponType obj)
        {
            OnWeaponChange?.Invoke(obj);
        }

        

        private int LoadHighScore()
        {
            return saveSystem.Load().Highscore;
        }

        private void SaveHighScore(int playerScore)
        {
            if (playerHighscore >= playerScore)
            {
                return;
            }
            saveSystem.Save(new PPSaveSystemData() { Highscore = playerScore });
        }


        public void OnScoreChange(int score)
        {
            playerCurrentscore = score;
            OnPlayerScoreChange?.Invoke(score);
        }


    }
}
