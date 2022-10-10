using Core.PoolSystem;
using System.Collections;
using System.Collections.Generic;
using Units;
using UnityEngine;
using Zenject;

namespace ViewSystem.Views
{
    public class GameplayManager : MonoBehaviour
    {
        private Player player;
        private PoolManager poolManager;

        private Player GetPlayer()
        {
            return player;
        }

        [Inject]
        private void Construct(PoolManager poolManager, Player player)
        {
            this.poolManager = poolManager;
            this.player = player;
        }
    }
}