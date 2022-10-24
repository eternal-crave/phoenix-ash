using GameFlow;
using GameplayLogicProcessor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ViewSystem.Views;
using ViewSystem.Views.Gameplay;
using Weapons;
using Zenject;

namespace GameFlow.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private WeaponType defaultPlayerWeapon;

        [Header("Enemies")]
        [SerializeField] private int pointsForEnemyKill = 1;
        [SerializeField] private float enemyCreationInterval = 2;
        [SerializeField] private float creationOffsetFromEdges = 100f;

        [Header("Gameplay Logic")]
        [SerializeField] private GameplayProcessor gameplayProcessor;

        private GameplayManager gameplayManager;
        private GameFlow gameFlow;

        [Inject]
        private void Construct(GameFlow flow, GameplayManager gameplayManager)
        {
            this.gameplayManager = gameplayManager;
            gameFlow = flow;
        }
        private void Start()
        {
            gameplayManager.SetGamePlayProcessorLogic(gameplayProcessor);
            gameplayManager.SetInitialValues(pointsForEnemyKill, enemyCreationInterval, defaultPlayerWeapon, creationOffsetFromEdges);
            gameFlow.StartGameFlow();
        }
    }
}
