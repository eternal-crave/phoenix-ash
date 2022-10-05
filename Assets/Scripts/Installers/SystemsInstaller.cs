using Assets.Scripts.Core.ViewSystem.Test;
using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using System.Collections.Generic;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    [SerializeField] Transform gameplayInputContainer;
    [SerializeField] GameplayInput gameplayInput;

    public override void InstallBindings()
    {
        var input = Container.InstantiatePrefabForComponent<GameplayInput>(gameplayInput, gameplayInputContainer);
        Container.Bind<GameplayInput>().FromInstance(input).AsSingle();
    }

}