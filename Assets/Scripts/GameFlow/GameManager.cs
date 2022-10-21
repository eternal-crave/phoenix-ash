using GameFlow;
using System;
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
        [SerializeField] private int pointsForEnemyKill = 1;
        [SerializeField] private float enemyCreationInterval = 2;
        [SerializeField] private WeaponType defaultPlayerWeapon = WeaponType.Single;
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
            gameplayManager.SetInitialValues(pointsForEnemyKill, enemyCreationInterval, defaultPlayerWeapon);
            gameFlow.StartGameFlow();
        }
    }
}
