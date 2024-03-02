using System.Collections;
using Enums;
using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyAttack : MonoBehaviour 
    {
        public bool enemyAttackDecided = false;
        public float enemyDamage;
        public string enemyType = EnemyType.Wizard.ToString();

        
        [SerializeField] private ParticleSystem enemyAttackEffect;
        [SerializeField] private GameObject enemyAttackCenter;
        
        
        private PlayerHeal _playerHeal;

        
        private void Awake()
        {
            enemyAttackEffect.transform.position = enemyAttackCenter.transform.position.AddHeight(0.5f);
            enemyDamage = EnemyRandomData.Instance.GetRandomDamage();
            _playerHeal = FindObjectOfType<PlayerHeal>();
        }


        private void Attack()
        {
            if(ParticleCollisionDetector.isEnemyAttackHit) 
            {
                print("Player did hit the circle");
                _playerHeal.ReduceHealth(enemyDamage);
            }
            
        }

        public void AssignValueOfAttack()
        {
            StartCoroutine(WaitParticle());
        }

        private IEnumerator WaitParticle()
        {
            float attackRate = EnemyRandomData.Instance.GetRandomFireRate();
            enemyAttackDecided = true;
            yield return new WaitForSeconds(attackRate);
            enemyAttackEffect.Play();
            enemyAttackDecided = false;
            
        }
    }
}
