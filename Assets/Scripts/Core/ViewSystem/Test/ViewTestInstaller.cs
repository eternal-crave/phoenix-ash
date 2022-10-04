using Assets.Scripts.Core.ViewSystem.Test;
using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ViewTestInstaller : MonoInstaller
{
    [SerializeField] Transform instantiateContainer;
    private const string path = "ViewPrefabs\\";
    public override void InstallBindings()
    {
        RegisterView<TestView, TestPresenter>();
        RegisterView<TestView1, TestPresenter1>();
        SetDependenciesForViewManager(); // Move to another installer maybe
        Container.Bind<TestGameFlow>().AsSingle(); // for test


    }

    private void RegisterView<V, P>() where V : View, new() where P : Presenter
    {
        V view = (V)Container.InstantiatePrefabResourceForComponent<View>(path+typeof(V).Name, instantiateContainer);
        Container.Bind<View>().To<V>().FromInstance(view).AsSingle().WhenInjectedInto<P>().NonLazy();
        Container.Bind<Presenter>().To<P>().AsSingle().NonLazy();
    }

    private void SetDependenciesForViewManager()
    {
        Container.Bind<ViewManager>().AsSingle().NonLazy();
    }


}