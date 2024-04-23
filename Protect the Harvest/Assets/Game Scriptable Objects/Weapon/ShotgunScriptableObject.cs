using UnityEngine;

namespace Game_Scriptable_Objects.Weapon
{
    [CreateAssetMenu(fileName = "Shotgun", menuName = "Protect the Harvest/Weapon/Shotgun" ,order = 2)]
    public class ShotgunScriptableObject : ObjectsScriptableData
    {
        [Range(0,1f)]
        public float hitRadius;
    }
}