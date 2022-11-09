using SerializableDictionaries;
using UnityEngine;
using Weapons;

namespace GameConfiguration
{
    public class GameConfig : ScriptableObject
    {
        [Header("Player")]
        public readonly WeaponType DefaultPlayerWeapon;

        [Header("Enemies")]
        public readonly int PointsForEnemyKill = 1;
        public readonly float EnemyCreationInterval = 2;
        public readonly float CreationOffsetFromEdges = 100f;

        public readonly WeaponTypeIntDictionary WeaponPointsPair;
    }
}