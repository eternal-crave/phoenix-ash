using Core.ViewSystem.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ViewSystem.Views;
using Units;

namespace ViewSystem.Presenters
{
    public class GameViewPresenter : Presenter
    {
        private GameView view;

        private int playerHealth;
        private int playerScore;

        public GameViewPresenter(View view, Player player) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
            view = ((GameView)View);
        }
        public override void Init(Action onClose)
        {
            base.Init(onClose);
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
            view.Close();
        }
    }
}
