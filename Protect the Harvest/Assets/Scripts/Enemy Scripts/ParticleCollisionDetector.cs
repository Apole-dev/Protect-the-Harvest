using System.Collections;
using UnityEngine;

namespace Enemy_Scripts
{
    public class ParticleCollisionDetector : MonoBehaviour
    {
        public static bool isEnemyAttackHit { get; private set; } = false;
        

        private void OnParticleTrigger()
        {
            print("OnParticleTrigger");
            isEnemyAttackHit = true;
            print(isEnemyAttackHit);
            StartCoroutine(Pass());
            print("after"+isEnemyAttackHit);
        }

        private IEnumerator Pass()
        {
            yield return new WaitForSeconds(3f);
            isEnemyAttackHit = false;
        }
    }
}