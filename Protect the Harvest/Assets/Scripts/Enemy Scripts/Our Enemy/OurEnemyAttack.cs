using System;
using Player_Scripts;
using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyAttack : MonoBehaviour
    {
        private PlayerHeal _playerHeal;
        
        private void Awake()
        {
            _playerHeal = GetComponent<PlayerHeal>();
        }

        public void Attack(int damage)
        {
            print("Our Enemy Attacked");
            //_playerHeal.ReduceHealth(damage);
            //todo remove
        }

        public void AttackEffect(Transform positionOfEffect,GameObject effect)
        {
            effect.transform.position = positionOfEffect.position;
        }
        public void StopAttack()
        {
            
        }

        public void ResetAttack()
        {
            
        }
    }
}