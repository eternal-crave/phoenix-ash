using Core.ViewSystem.Core;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;

namespace Scripts.GameFlow
{
    public class GameFlow
    {
        private ViewManager viewManager;

        public GameFlow(ViewManager viewManager)
        {
            this.viewManager = viewManager;
        }

        public void StartGameFlow()
        {
            OpenStartView();
        }

        private void OpenStartView()
        {
            StartViewPresenter presenter = viewManager.OpenView<StartView, StartViewPresenter>();
            presenter.Init(OpenGameView);
        }

        private void OpenGameView()
        {
            GameViewPresenter presenter = viewManager.OpenView<GameView, GameViewPresenter>();
            presenter.Init(null);

        }
    }
}
