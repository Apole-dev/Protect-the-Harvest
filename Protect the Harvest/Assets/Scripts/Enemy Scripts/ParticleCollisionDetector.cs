using UnityEngine;

namespace Enemy_Scripts
{
    public class ParticleCollisionDetector : MonoBehaviour
    {
        public  bool isEnemyAttackHit { get; set; } = false;

        private void OnParticleTrigger()
        {
            print("OnParticleTrigger");
            isEnemyAttackHit = true;
        }
    }
}