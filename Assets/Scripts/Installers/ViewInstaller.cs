using UnityEngine;
using ViewSystem.Views;
using Zenject;
using Core.ViewSystem;

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