using Zenject;
using Core.ViewSystem;

namespace Installers
{
    public class FlowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ViewManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameFlow.GameFlow>().AsSingle().NonLazy();
        }
    }
}