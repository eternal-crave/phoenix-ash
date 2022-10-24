using UnityEngine;
using UnityEditor;
using SerializableDictionaries;

namespace Assets.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(IntWeaponTypeDictionary))]
    public class IntWeaponTypeDictionaryDrawer : SerializableDictionaryPropertyDrawer
    {
    }
}
