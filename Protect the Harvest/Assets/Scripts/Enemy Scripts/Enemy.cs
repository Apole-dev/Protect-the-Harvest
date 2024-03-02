using System.Collections;
using Interfaces;
using UnityEngine.UI;
using UnityEngine;

namespace Enemy_Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour , IEnemy
    {
        #region Script Acsesser
        private EnemyHealth _enemyHealth;
        #endregion
        

        #region Game Acsessers
        
        [SerializeField] private Slider healthBar;
        [SerializeField] private new ParticleSystem particleSystem;
        
        #endregion

        #region Enemy Properties 
        
        [HideInInspector]
        public EnemyProperties enemyProperties;
        
        [Header("Enemy Stats")]
        public int health;
        public int damage;
        public int moveSpeed;
        public int attackRate;

        private int _tempHealth;
        private int _tempDamage;
        private int _tempMoveSpeed;
        private int _tempAttackRate;
        
        public static int killedEnemies = 0;
        public bool isInPool = false;
        
        #endregion
        
        
        private void OnEnable()
        {
            if (isInPool)
            {
                _enemyHealth.AssignHealth(healthBar,_tempHealth);
            }
        }


        private void Awake()
        {
        
            _enemyHealth = FindObjectOfType<EnemyHealth>();
        }

        private void Start()
        {
            _tempDamage = damage;
            _tempHealth = health;
            _tempMoveSpeed = moveSpeed;
            _tempAttackRate = attackRate;
            
            _enemyHealth.AssignHealth(healthBar, health);
        }
        
        
        public void ReduceHealth(float playerDamage)
        {
           bool isDead = _enemyHealth.ReduceHealth(playerDamage, healthBar);
           
           if (isDead)
           {
               print("Enemy died");
                   
               killedEnemies++;
               StartCoroutine(PlayParticleEffect());
               
               MoveToThePool();
           }
        }

        private IEnumerator PlayParticleEffect()
        {
            yield return new WaitForSeconds(0.3f);
            particleSystem.Play();
        }

        public void MoveToThePool()
        {
           EnemyPooling.Instance.MoveEnemyToPool(this); 
        }

        public void ReturnFromPool()
        {
            EnemyPooling.Instance.ReturnEnemyFromPool(this);
        }
    }
}

