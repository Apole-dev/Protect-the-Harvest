using Enums;
using UnityEngine;

namespace Scriptable_Objects
{
    //Refactor this separate the scriptable objects by their object type. 
    [CreateAssetMenu(fileName = "ResourceObject", menuName = "Protect the Harvest/Resource Object", order = 1)]
    public class ResourceObject :ScriptableObject
    {
        [Tooltip("Indicates to object type"),]
        public ObjectType objectType;

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