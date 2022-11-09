using Core.SaveSystem.PlayerPrefsSaveSystem;
using Core.ViewSystem.Core;
using System;
using Units;
using UnityEngine;
using ViewSystem.Views;
using Weapons;

namespace GameFlow
{
    public class GameFlow
    {

        private ViewManager viewManager;
        private Player player;
        
        public event Action OnGameStart;
        public event Action OnEndGame;



        public GameFlow(ViewManager viewManager, Player player)
        {
            this.viewManager = viewManager;  
            this.player = player;
        }

        public void StartGameFlow()
        {
            OpenStartView();
        }

        private void OpenStartView()
        {
            StartView view = viewManager.OpenView<StartView>();
            view.Init(OpenGameView);
        }

        private void OpenGameView()
        {
            GameView view = viewManager.OpenView<GameView>();
            view.Init(() =>
            {
                OpenGameOverScreen();
                OnEndGame?.Invoke();
            });
            OnGameStart.Invoke();
        }


        private void OpenGameOverScreen()
        {
            GameOverView view = viewManager.OpenView<GameOverView>();
            view.AddListenerToHomeButton(OpenStartView);
            view.AddListenerToRestartButton(OpenGameView);
            view.Init(() =>
            {
                view.RemoveButtonsLiateners();
            });
        }    
    }
}
