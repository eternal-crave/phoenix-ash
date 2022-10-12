using GameFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace GameFlow.Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameFlow gameFlow;

        [Inject]
        private void Construct(GameFlow flow)
        {
            gameFlow = flow;
        }
        private void Start()
        {
            gameFlow.StartGameFlow();
        }
    }
}
