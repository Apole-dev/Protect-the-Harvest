using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyHit : MonoBehaviour
    {
        public float TakeDamage(float health,float damage)
        {
            health -= damage;
            if(health <= 0) print("Dead");
            return health;
        }

        public void PushBack(Rigidbody rb,float pushAmount)
        {
            rb.AddForce(pushAmount, 0, 0, ForceMode.Impulse);
        }
    }
}