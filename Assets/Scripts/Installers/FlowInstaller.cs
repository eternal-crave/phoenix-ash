using GameFlow.Managers;
using Core.ViewSystem.Core;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FlowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ViewManager>().AsSingle().NonLazy();
            Container.Bind<GameFlow.GameFlow>().AsSingle().NonLazy();
        }
    }
}