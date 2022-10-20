using GameFlow.Managers;
using Core.ViewSystem.Core;
using System.Collections.Generic;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;
using Zenject;

namespace Installers
{
    public class ViewInstaller : MonoInstaller
    {
        [SerializeField] Transform instantiateContainer;
        private const string path = "ViewPrefabs\\";
        public override void InstallBindings()
        {
            RegisterView<StartView, StartViewPresenter>();
            RegisterView<GameView, GameViewPresenter>();
            RegisterView<GameOverView, GameOverViewPresenter>();

        }

        private void RegisterView<V, P>() where V : View, new() where P : Presenter
        {
            V view = (V)Container.InstantiatePrefabResourceForComponent<View>(path + typeof(V).Name, instantiateContainer);
            Container.Bind<View>().To<V>().FromInstance(view).AsSingle().WhenInjectedInto<P>().NonLazy();
            Container.Bind<Presenter>().To<P>().AsSingle().NonLazy();
        }
    }
}