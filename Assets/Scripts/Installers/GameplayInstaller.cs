using Assets.Scripts.Core.ViewSystem.Test;
using Core.ViewSystem.Core;
using Core.ViewSystem.Test.TestPool;
using System.Collections.Generic;
using Units;
using UnityEngine;
using ViewSystem.Presenters;
using ViewSystem.Views;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] Transform gameplayInputContainer;
        [SerializeField] GameplayInput gameplayInput;
        [SerializeField] Player playerPrefab;
        [SerializeField] Transform playerSpawnPoint;

        public override void InstallBindings()
        {
            BindGameplayInput();
            BindPlayer();

        }

        private void BindGameplayInput()
        {
            var input = Container.InstantiatePrefabForComponent<GameplayInput>(gameplayInput, gameplayInputContainer);
            Container.Bind<GameplayInput>().FromInstance(input).AsSingle();
        }

        private void BindPlayer()
        {
            var player = Container.InstantiatePrefabForComponent<Player>(playerPrefab, playerSpawnPoint);
            Container.Bind<Player>().FromInstance(player).AsSingle();
        }
    }
}