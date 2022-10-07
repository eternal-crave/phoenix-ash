using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitSystem
{
    public interface IGetDamage
    {
        event Action<float> OnGetDamage;
        event Action OnDead;
        void GetDamage(float damage);
    }
}
