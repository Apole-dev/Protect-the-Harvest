using UnityEngine;

namespace Enemy_Scripts
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        [Header("Health Stats")]
        public float maxHealth;
        public float minHealth;
        [Space]
        
        [Header("Attack Stats")]
        public float maxDamage;
        public float minDamage;
        [Space]
        
        [Header("Movement Stats")]
        public float maxSpeed;
        public float minSpeed;
        [Space]
        
        [Header("Fire Stats")]
        public float maxFireRate;
        public float minFireRate;
     
        
    }
}