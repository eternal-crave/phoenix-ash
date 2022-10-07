using Assets.Scripts.Factories;
using Core.Factory;
using Core.PoolSystem;
using System;
using Units;
using UnityEngine;
using ViewSystem.Views;
using Weapons;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] Transform gameplayInputContainer;
        [SerializeField] GameplayInput gameplayInput;
        [SerializeField] Player playerPrefab;
        [SerializeField] Transform playerSpawnPoint;
        [SerializeField] PoolManager poolManager;

        public override void InstallBindings()
        {
            BindFactories();
            BindManagers();
            BindGameplayInput();
            Container.Bind<SingleWeapon>().AsSingle();  //////////////// FORTEST
            BindPlayer();
        }

        private void BindFactories()
        {
            BindFactory<BulletFactory>();
        }

        private void BindManagers()
        {
            Container.Bind<FactoryManager>().AsSingle();
            Container.Bind<PoolManager>().FromInstance(poolManager).AsSingle();
        }

        private void BindFactory<F>() where F : IFactoryMarker
        {
            Container.Bind<IFactoryMarker>().To<F>().AsSingle();
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