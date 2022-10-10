using Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units;
using UnityEngine;

namespace Assets.Scripts.Factories
{
    internal class EnemyFactory : Factory<Enemy>
    {
        protected override string path => "Units\\";

        public EnemyFactory()
        {
            instance = Resources.Load<Enemy>(path + typeof(Enemy).Name);
        }

        public override Enemy Create()
        {
            return UnityEngine.Object.Instantiate(instance);
        }
    }
}
