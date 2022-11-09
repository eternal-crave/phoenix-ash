using UnityEngine;
using UnityEditor;
using SerializableDictionaries;

namespace Assets.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(WeaponTypeIntDictionary))]
    public class WeaponTypeIntDictionaryDrawer : SerializableDictionaryPropertyDrawer
    {
    }
}
