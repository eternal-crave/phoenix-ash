using Assets.Scripts.Factories;
using Core.Factory;
using Core.PoolSystem;
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
            BindFactoryManager();
            BindGameplayInput();
            Container.Bind<PoolManager>().FromInstance(poolManager).AsSingle();
            Container.Bind<SingleWeapon>().AsSingle();
            Container.Bind<Core.Factory.Factory<IFactoryItemPlaceHolder>>().To<BulletFactory>();
            BindPlayer();

        }

        private void BindFactoryManager()
        {
            Container.Bind<FactoryManager>().AsSingle();
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