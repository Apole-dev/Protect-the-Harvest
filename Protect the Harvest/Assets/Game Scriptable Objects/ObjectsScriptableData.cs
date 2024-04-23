using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Scriptable_Objects
{
    public class ObjectsScriptableData : ScriptableObject
    {
        public Rarity rarity;
        
        public int effectValue;
        [Tooltip("Fire Rate Per Second")] [Range(0, 3)]
        public float fireRate;
        public float bulletSpeed;
        public float bulletLifeTime;
        public float pushAmount;
        public int range;
        
        public GameObject objectPrefab;
        public GameObject bulletPrefab;
        public Image objectImage;
    }
}