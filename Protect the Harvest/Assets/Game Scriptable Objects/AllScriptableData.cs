using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Scriptable_Objects
{
    public class AllScriptableData : ScriptableObject
    {
        public Rarity rarity;
        public int damage;
        public int range;

        public GameObject weaponPrefab;
        public Image weaponImage;
    }
}