using Assets.Scripts.Factories;
using Core.Factory;
using Core.PoolSystem;
using Core.SaveSystem.PlayerPrefsSaveSystem;
using Core.ScoreSystem;
using Core.ViewSystem;
using GameConfiguration;
using Units;
using UnityEngine;
using ViewSystem.Views;
using ViewSystem.Views.Gameplay;
using Weapons;
using Zenject;

namespace Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [Header("Player")]
        [SerializeField] Player playerPrefab;
        [SerializeField] Transform playerSpawnPoint;

        [Header("Game Configuration")]
        [SerializeField] GameConfig gameConfig;

        [Header("Input System")]
        [SerializeField] Transform gameplayInputContainer;
        [SerializeField] GameplayInput gameplayInput;

        [Header("Views")]
        [SerializeField] Transform instantiateContainer;
        private const string path = "ViewPrefabs\\";

        public override void InstallBindings()
        {
            BindScoreSystem();
            BindGameConfiguration();
            BindSaveSystem();
            BindFactories();
            BindGameplayInput();
            BindPlayer();
            BindWeapons();
            BindManagers();
        }

        private void BindScoreSystem()
        {
            Container.Bind<ScoreCounter>().AsSingle();
        }

        private void RegisterViews()
        {
            RegisterView<StartView>();
            RegisterView<GameView>();
            RegisterView<GameOverView>();

        }

        private void RegisterView<V>() where V : View
        {
            V view = Container.InstantiatePrefabResourceForComponent<V>(path + typeof(V).Name, instantiateContainer);
            Container.Bind<View>().To<V>().FromInstance(view).AsSingle().NonLazy();
        }

        private void BindGameplayInput()
        {
            var input = Container.InstantiatePrefabForComponent<GameplayInput>(gameplayInput, gameplayInputContainer);
            Container.Bind<GameplayInput>().FromInstance(input).AsSingle();
        }

        private void BindFactories()
        {
            BindFactory<BulletFactory>();
            BindFactory<EnemyFactory>();
        }
        private void BindManagers()
        {
            Container.Bind<FactoryManager>().AsSingle();
            Container.Bind<PoolManager>().AsSingle();
            Container.Bind<WeaponManager>().AsSingle();
            BindViewManager();
            Container.BindInterfacesAndSelfTo<GameFlow.GameFlow>().AsSingle().NonLazy();
            Container.Bind<GameplayManager>().AsSingle().NonLazy();
        }

        private void BindViewManager()
        {
            RegisterViews();
            Container.Bind<ViewManager>().AsSingle().NonLazy();
        }

        private void BindFactory<F>() where F : IFactoryMarker
        {
            Container.Bind<IFactoryMarker>().To<F>().AsSingle();
        }

        void BindWeapons()
        {
            Container.Bind<Weapon>().To<SingleWeapon>().AsSingle();
            Container.Bind<Weapon>().To<QueueWeapon>().AsSingle();
            Container.Bind<Weapon>().To<ShotGunWeapon>().AsSingle();
        }

        private void BindSaveSystem()
        {
            Container.Bind<PPSaveSystem>().AsSingle();
        }
        private void BindPlayer()
        {
            Player player = Container.InstantiatePrefabForComponent<Player>(playerPrefab, playerSpawnPoint);
            Container.Bind<Player>().FromInstance(player).AsSingle();
        }
        private void BindGameConfiguration()
        {
            Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
        }
    }
}
