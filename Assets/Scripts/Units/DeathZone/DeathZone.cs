using Core.UnitSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Units.DeathZone
{
    public class DeathZone : MonoBehaviour, IDeathZone
    {
        private Player player;
        [Inject]
        private void Construct(Player player)
        {
            this.player = player;
        }
        public IGetDamage GetDamageable()
        {
            return player;
        }
    }
}
