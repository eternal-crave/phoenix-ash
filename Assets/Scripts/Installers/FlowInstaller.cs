using Assets.Scripts.Core.ViewSystem.Test;
using Core.ViewSystem.Core;
using Scripts.GameFlow;
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
            Container.Bind<GameFlow>().AsSingle().NonLazy();
        }
    }
}