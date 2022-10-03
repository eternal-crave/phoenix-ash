using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    [SerializeField] ViewManager viewManager;
    public override void InstallBindings()
    {
        viewManager.InstantiateViews(Container);
    }
   
}