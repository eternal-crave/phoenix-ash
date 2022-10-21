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
        private void Start()
        {
            ConfigureScale();
        }

        private void ConfigureScale()
        {
            Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);

            Vector3 center = (upperRight + lowerLeft);
            Vector3 centerRight = new Vector3(upperRight.x, center.y, center.z);

            Vector3 scale = center - centerRight;
            transform.localScale = new Vector3(scale.x * 2, transform.localScale.y, transform.localScale.z);
        }
    }
}
