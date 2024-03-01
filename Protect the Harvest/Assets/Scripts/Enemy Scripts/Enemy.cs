using System;
using System.Collections;
using Interfaces;
using UnityEngine.UI;
using UnityEngine;


namespace Enemy_Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour , IEnemy
    {
        private EnemyPooling _enemyPooling;
        private EnemyHealth _enemyHealth;
        
        public static int killedEnemies = 0;
        
        [SerializeField] private Slider healthBar;
        [SerializeField] private new ParticleSystem particleSystem;
        
        public float health;
        public float damage;
        public float moveSpeed;
        public float attackRate;
        
        private float _tempHealth;
        private float _tempDamage;
        private float _tempMoveSpeed;
        private float _tempAttackRate;
        
        private bool isInPool = false;
        


        private void OnEnable()
        {
            if (!isInPool) return;
            damage = _tempDamage;
            health = _tempHealth;
            moveSpeed = _tempMoveSpeed;
            attackRate = _tempAttackRate;
            
            healthBar.maxValue = health;
        }


        private void Awake()
        {
            _enemyPooling = FindObjectOfType<EnemyPooling>();
            _enemyHealth = FindObjectOfType<EnemyHealth>();
        }

        private void Start()
        {
            _tempDamage = damage;
            _tempHealth = health;
            _tempMoveSpeed = moveSpeed;
            _tempAttackRate = attackRate;
        }

        private void Update()
        {
            print("Health: " + health );
        }


        public void ReduceHealth(float playerDamage)
        {
           bool isDead = _enemyHealth.ReduceHealth(playerDamage, healthBar);
           print(isDead);
           print("Reduce health is working +" + playerDamage);
           if (isDead)
           {
               print("Enemy died");
               killedEnemies++;
               StartCoroutine(PlayParticleEffect());
               _enemyPooling.MoveEnemyToPool(gameObject);
               isInPool = true;
           }
        }

        private IEnumerator PlayParticleEffect()
        {
            yield return new WaitForSeconds(0.3f);
            particleSystem.Play();
        }
        
    }
}

