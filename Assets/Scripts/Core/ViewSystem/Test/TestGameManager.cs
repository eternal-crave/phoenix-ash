using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Core.ViewSystem.Test
{
    public class TestGameManager : MonoBehaviour
    {
        private TestGameFlow flow;

        [Inject]
        private void Construct(TestGameFlow flow)
        {
            this.flow = flow;
        }
        private void Start()
        {
            flow.StartGameFlow();
        }
    }
}
