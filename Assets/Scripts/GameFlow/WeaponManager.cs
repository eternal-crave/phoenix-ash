using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weapons;

namespace GameFlow.Managers
{
    public class WeaponManager
    {
        private List<Weapon> weapons;

        public WeaponManager(List<Weapon> weapons)
        {
            this.weapons = weapons;
        }

        public W GetWeapon<W>() where W : Weapon
        {
            return (W)weapons.FirstOrDefault(w => w.GetType() == typeof(W));
        }
    }
}
