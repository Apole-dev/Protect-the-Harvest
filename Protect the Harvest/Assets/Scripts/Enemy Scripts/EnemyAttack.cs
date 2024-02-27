using System;
using Player_Scripts;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyAttack : MonoBehaviour
    {
        public static float enemyDamage;
        public static string enemyType = "Normal";

        
        [SerializeField] private ParticleSystem attackEffect;
        private PlayerHeal _playerHeal;

        private void Awake()
        {
            _playerHeal = FindObjectOfType<PlayerHeal>();
        }

        public void Attack()
        {
            //REFACTOR HERE
            enemyDamage = EnemyRandomData.Instance.GetRandomDamage();
            print("Enemy Attack Damage: " + enemyDamage);
            
            attackEffect.Play();
            
            if(ParticleCollisionDetector.isEnemyAttackHit) 
            {
                //BUG need more fix if character on the particle then it get hit WHEN GET INSIDE AUTOMATICALLY SHOULD IT
                _playerHeal.ReduceHealth(enemyDamage);
            }
        }
        
        
    }
}
