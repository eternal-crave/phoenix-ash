using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using UnityEngine;
using Zenject;

public class ViewInstaller : MonoInstaller
{
    [SerializeField] Transform instantiateContainer;
    [SerializeField] bool defaultActiveState = false;
    private const string path = "ViewPrefabs\\";
    public override void InstallBindings()
    {
        RegisterView<TestView, TestPresenter>();
    }

    private void RegisterView<V, P>() where V : View, new() where P : Presenter
    {
        V view = (V)Container.InstantiatePrefabResourceForComponent<View>(path+typeof(V).Name, instantiateContainer);
        view.gameObject.SetActive(defaultActiveState);
        Container.Bind<View>().To<V>().FromInstance(view).AsSingle().WhenInjectedInto<P>();
        Container.Bind<Presenter>().To<P>().AsSingle().NonLazy();
    }

}