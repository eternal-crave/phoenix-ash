using Core.UnitSystem;
using UnityEngine;

namespace Units.DeathZone
{
    public interface IDeathZone
    {
        IGetDamage GetDamageable();
    }
}