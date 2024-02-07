using Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceObject", menuName = "Protect the Harvest/Resource Object", order = 1)]
public class ResourceObject :ScriptableObject
{
    [Tooltip("Indicates to object type"),]
    public ObjectType objectType;

    [Tooltip("Indicates to object rarity")]
    public Rarity rarity;

    [Tooltip("Name of Game object")] 
    public new string name ;

    [Tooltip("Detail explanation of object")] [TextArea(2,5)]
    public string explanationOfObject;

    [Tooltip("Positive Effect value of object")] 
    [Range(1f,25f)]
    public float effectValue;

    [Tooltip("3D Game object ")]
    public GameObject gameObject;
        
    [Tooltip("Image for show from UI")]
    public Sprite gameObjectImage;
    
    [Tooltip("Sound Effect of object")] 
    public AudioClip soundEffect;
        
   
}