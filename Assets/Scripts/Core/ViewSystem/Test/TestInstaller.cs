using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        
        Container.Bind<View>().To<TestView>().AsSingle().WhenInjectedInto<TestPresenter>();
        Container.Bind<Presenter>().To<TestPresenter>().AsSingle().WhenInjectedInto<TestView>();
        ViewSystem.SetupView<TestPresenter, TestView>();
        
    }
   
}