using Core.Factory;
using System;
using UnityEngine;
using Weapons;

namespace Assets.Scripts.Factories
{
    public class BulletFactory : Factory<Bullet>
    {
        protected override string path => "Bullets\\";


        public BulletFactory()
        {
            instance = Resources.Load<Bullet>(path + typeof(Bullet).Name);
        }

        public override Bullet Create()
        {
            return UnityEngine.Object.Instantiate(instance);
        }
    }
}
