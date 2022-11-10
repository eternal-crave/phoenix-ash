using Core.ViewSystem;
using System;
using Units;
using ViewSystem.Views;
using Zenject;

namespace GameFlow
{
    public class GameFlow : IInitializable
    {

        private ViewManager viewManager;
        
        public event Action OnGameStart;
        public event Action OnEndGame;



        public GameFlow(ViewManager viewManager)
        {
            this.viewManager = viewManager;  
        }

        public void Initialize()
        {
            StartGameFlow();
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
                view.RemoveButtonsListeners();
            });
        }

        
    }
}
