using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitSystem
{
    public interface IGetDamage
    {
        event Action<int> OnGetDamage;
        void GetDamage(float damage);
    }
}
