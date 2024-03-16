using UnityEngine;

namespace Enemy_Scripts
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Protect the Harvest/Enemy/EnemyData", order = 1)]
    public class EnemyData : ScriptableObject
    {
        [Header("Health Stats")]
        public int maxHealth;
        public int minHealth;
        [Space]
        
        [Header("Attack Stats")]
        public int maxDamage;
        public int minDamage;
        [Space]
        
        [Header("Movement Stats")]
        public int maxSpeed;
        public int minSpeed;
        [Space]
        
        [Header("Fire Stats")]
        public int maxFireRate;
        public int minFireRate;
     
        
    }
}