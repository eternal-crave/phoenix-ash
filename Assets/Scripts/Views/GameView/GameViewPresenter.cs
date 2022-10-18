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
        private Player player;

        public GameViewPresenter(View view, Player player) : base(view)
        {
            Debug.Log($"From {GetType()}::: This is my view:{View.GetType()}");
            this.player = player;
        }
        public override void Init(Action onClose)
        {
            ((GameView)View).SetValues((int)player.Health, 0);
            base.Init(onClose);
        }
    }
}
