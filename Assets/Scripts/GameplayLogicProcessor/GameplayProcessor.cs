using SerializableDictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Weapons;

namespace GameplayLogicProcessor
{
    [CreateAssetMenu(fileName = "BasicGameplayProcessor", menuName = "GamePlayProcessors/BasicGameplayProcessor")]
    public class GameplayProcessor : ScriptableObject
    {
        public event Action<WeaponType> OnNewWeaponGain;

        [SerializeField] private IntWeaponTypeDictionary weaponPointsPair;


        public void Check(int points)
        {
            if (weaponPointsPair.ContainsKey(points))
            {
                OnNewWeaponGain?.Invoke(weaponPointsPair[points]);
            }
        }
    }
}
