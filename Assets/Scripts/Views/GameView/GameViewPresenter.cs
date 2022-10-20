using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;
using Units;
using Weapons;

namespace ViewSystem.Presenters
{
    public class GameViewPresenter : Presenter
    {
        public Action<WeaponType> OnWeaponChange;

        private GameView view;

        private int playerHealth;
        private int playerScore;

        public int PlayerScore => playerScore;

        public GameViewPresenter(View view, Player player) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
            this.view = (GameView)view;
        }

        private void WeaponChangeInput(WeaponType obj)
        {
            OnWeaponChange?.Invoke(obj);
        }

        public override void Init(Action onClose)
        {
            base.Init(onClose);
            this.view.OnWeaponChange += WeaponChangeInput;
        }

        public void SetValues(int health, int score)
        {
            playerHealth = health;
            playerScore = score;
            view.SetValues(health, score);
        }

        public void OnPlayerGetDamage(float damage)
        {
            playerHealth -= (int)damage;
            view.SetHealth(playerHealth);
        }

        public void OnPlayerDead()
        {
            view.CloseView();
            this.view.OnWeaponChange -= WeaponChangeInput;
        }

        public void SetScore(int score)
        {
            playerScore = score;
            view.SetScore(score);
        }
    }
}
