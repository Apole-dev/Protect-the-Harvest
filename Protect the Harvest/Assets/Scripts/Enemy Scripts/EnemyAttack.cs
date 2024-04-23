using System.Collections;
using Managers;
using Player_Scripts;
using Singleton;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy_Scripts
{
    public class EnemyAttack : MonoSingleton<EnemyAttack>
    {
        public GameObject enemyAttackParticleObject;
        public Transform enemyAttackPoint;

        
        
        public GameObject InstantiateEnemyAttackParticle()
        {
            return Instantiate(enemyAttackParticleObject, RandomPositionForParticle(), Quaternion.identity);
        }

        private Vector3 RandomPositionForParticle()
        {
            var position = enemyAttackPoint.position;
            float randomX = Random.Range(position.x - 5f, position.x + 5f);
            float randomZ = Random.Range( position.z - 5f, position.z + 5f);
            
            return new Vector3(randomX, 0.3f, randomZ);
        }
        
    }
}
