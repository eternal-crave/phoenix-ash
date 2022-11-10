using SerializableDictionaries;
using UnityEngine;
using Weapons;

namespace GameConfiguration
{
    [CreateAssetMenu(fileName = "GameConfigSample", menuName = "GameConfig/GameConfigSample")]
    public class GameConfig : ScriptableObject
    {
        [Header("Player")]
        [SerializeField] private WeaponType defaultPlayerWeapon;

        [Header("Enemies")]
        [SerializeField] private int pointsForEnemyKill = 1;
        [SerializeField] private float enemyCreationInterval = 2;
        [SerializeField] private float creationOffsetFromEdges = 100f;

        [Header("Logic")]
        [SerializeField] private WeaponTypeIntDictionary weaponPointsPair;

        public WeaponType DefaultPlayerWeapon => defaultPlayerWeapon;

        public int PointsForEnemyKill => pointsForEnemyKill;
        public float EnemyCreationInterval => enemyCreationInterval;
        public float CreationOffsetFromEdges => creationOffsetFromEdges;
        public WeaponTypeIntDictionary WeaponPointsPair => weaponPointsPair;
    }
}