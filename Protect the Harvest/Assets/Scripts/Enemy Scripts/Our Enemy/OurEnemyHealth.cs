using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyHealth : MonoBehaviour
    {
        public float UpdateHealth(float currentHealth, float healAmount)
        {
            return currentHealth+healAmount;
        }

        public float ResetHealth(float health)
        {
            print("Health reset. Before value: " + health);
            health = 0;
            return health;
        }

        public void Death() 
        {
            print("Dead enemy!");
        }
    }
}