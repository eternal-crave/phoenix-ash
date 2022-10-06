using Core.Factory;
using System;
using UnityEngine;
using Weapons;

namespace Assets.Scripts.Factories
{
    public class BulletFactory : Factory<Bullet>
    {
        protected override string path => "Bullets";

        protected override Bullet Instance => bulletPrefab;

        public override Type ProductType => Instance.GetType();

        private Bullet bulletPrefab;

        public BulletFactory()
        {
            bulletPrefab = Resources.Load<Bullet>(path + typeof(Bullet).Name);
        }

        public override Bullet Create()
        {
            return UnityEngine.Object.Instantiate(bulletPrefab);
        }
    }
}
