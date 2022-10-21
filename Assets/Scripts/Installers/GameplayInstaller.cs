using Assets.Scripts.Factories;
using Core.Factory;
using Core.PoolSystem;
using Core.SaveSystem.PlayerPrefsSaveSystem;
using GameFlow.Managers;
using Units;
using UnityEngine;
using ViewSystem.Views;
using ViewSystem.Views.Gameplay;
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
            BindSaveSystem();
            BindPlayer();
            BindFactories();
            BindManagers();
            BindGameplayInput();
            BindWeapons();
        }


        void BindWeapons()
        {
            Container.Bind<Weapon>().To<SingleWeapon>().AsSingle();
            Container.Bind<Weapon>().To<QueueWeapon>().AsSingle();
            Container.Bind<Weapon>().To<SemiCircleWeapon>().AsSingle();
        }

        private void BindFactories()
        {
            BindFactory<BulletFactory>();
            BindFactory<EnemyFactory>();
        }

        private void BindManagers()
        {
            Container.Bind<GameplayManager>().AsSingle().NonLazy();
            Container.Bind<FactoryManager>().AsSingle();
            Container.Bind<WeaponManager>().AsSingle();
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

        private void BindSaveSystem()
        {
            Container.Bind<PPSaveSystem>().AsSingle();
        }


    }
}