using GameFlow.Managers;
using Core.ViewSystem.Core;
using System.Collections.Generic;
using UnityEngine;
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
            RegisterView<StartView>();
            RegisterView<GameView>();
            RegisterView<GameOverView>();

        }

        private void RegisterView<V>() where V : View
        {
            V view = (V)Container.InstantiatePrefabResourceForComponent<View>(path + typeof(V).Name, instantiateContainer);
            Container.Bind<View>().To<V>().FromInstance(view).AsSingle().NonLazy();
        }
    }
}