using Enums;
using UnityEngine;

namespace Scriptable_Objects
{
    //[CreateAssetMenu(fileName = "Weapon", menuName = "Protect the Harvest/Weapon Object", order = 3)]
    public class Shield : ScriptableObject
    {
        
        [Tooltip("Indicates to object rarity")]
        public Rarity rarity;
    
        [Tooltip("Indicates type of Gun")]
        public GunType gunType;
    
        [Tooltip("Positive Effect value of object")] 
        [Range(1,10)]
        public int effectValue;

        [Tooltip("3D Game object ")]
        public GameObject gameObject;
        
        [Tooltip("Image for show from UI")]
        public Sprite gameObjectImage;
    
        [Tooltip("Sound Effect of object")] 
        public AudioClip soundEffect;
    }
}