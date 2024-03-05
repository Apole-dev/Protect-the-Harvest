using System.Collections;
using Managers;
using Player_Scripts;
using Singleton;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyAttack : MonoSingleton<EnemyAttack> 
    {
        [SerializeField] private ParticleSystem enemyAttackEffect;
        [SerializeField] private GameObject enemyAttackCenter;
        
        
        private PlayerHeal _playerHeal;
        
        private void Awake()
        {
            enemyAttackEffect.transform.position = enemyAttackCenter.transform.position.AddHeight(0.5f);
            _playerHeal = FindObjectOfType<PlayerHeal>();
        }

        public void Attack(int enemyDamage)
        {
            print("Player did hit the circle");
            _playerHeal.ReduceHealth(enemyDamage);   
        }
        
    }
}
