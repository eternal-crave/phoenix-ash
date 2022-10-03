using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] ViewManager viewManager;
    public override void InstallBindings()
    {
        //Container.Bind<View>().To<TestView>().AsSingle().WhenInjectedInto<TestPresenter>();
       /* Container.InstantiatePrefabResource("ViewPrefabs\\TestView");
        Container.Bind<Presenter>().To<TestPresenter>().AsSingle();*/
        viewManager.InstantiateViews(Container);
    }
   
}