using System.Collections;
using Interfaces;
using Managers;
using Player_Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour , IEnemy
    {
        #region Enemy General Acsseser
        public static int deathEnemyCount;
        public bool isAttacking;
        public bool isInPool;
        #endregion
        

        #region Enemy Out Line Properties
        public int damage { get; set; }
        public int health { get; set; }
        public int speed { get; set; }
        public int fireRate { get; set; }
        #endregion

        #region Enemy Object Acsseser
        public Rigidbody enemyRigidBody { get; private set; }

        private ParticleCollisionDetector _particleCollisionDetector;
        private Slider _enemyHealthBar;
        private bool _attackTimerController = true;

        //Scripts
        private EnemyMovement _enemyMovement;
        private EnemyAttack _enemyAttack;
        private EffectManager _effectManager;
        private EnemyPooling _enemyPooling;
        private PlayerHeal _playerHeal;
        
        #endregion


        private void OnEnable()
        {
            _enemyHealthBar.value = health;
        }


        private void Awake()
        {
            
            _particleCollisionDetector = FindObjectOfType<ParticleCollisionDetector>();
            _enemyMovement = FindObjectOfType<EnemyMovement>();
            _effectManager = FindObjectOfType<EffectManager>();
            _enemyAttack = FindObjectOfType<EnemyAttack>();
            _enemyPooling = FindObjectOfType<EnemyPooling>();
            _playerHeal = FindObjectOfType<PlayerHeal>();
            
            enemyRigidBody = GetComponent<Rigidbody>();
            _enemyHealthBar = GetComponentInChildren<Slider>();
         
            
            isAttacking = false;
        }


        private void Start()
        {
            _enemyHealthBar.maxValue = health;
            _enemyHealthBar.value = health;
        }
        
        private void Update()
        {
            Attack();
        }

        private void FixedUpdate()
        {
            MoveEnemy();
            RotateEnemy();
        }

        
        /// <summary>
        /// Attack when "isAttacking" is true and if "particleCollisionDetector.isEnemyAttackHit" is true
        /// it will call "Attack()" function after that "particleCollisionDetector.isEnemyAttackHit" will be false
        /// </summary>
        private void Attack()
        {
            if (_attackTimerController)
            {
                StartCoroutine(AttackTimer());
                _attackTimerController = false;
            }
            
            if (isAttacking)
            {
                print("isAttacking");
                _effectManager.PlayEnemyAttackEffect();
                isAttacking = false;
            }       
            if (_particleCollisionDetector.isEnemyAttackHit)
            {
                _enemyAttack.Attack(damage);
                _particleCollisionDetector.isEnemyAttackHit = false;
            }
        }
        

        /// <summary>
        /// Attack timer, when enemy shoots it will stop "isAttacking" after 2 seconds
        /// and enemy will be stop when enemy shooting
        /// </summary>
        /// <returns></returns>
        private IEnumerator AttackTimer()
        {
            isAttacking = true;
            yield return new WaitForSeconds(fireRate);
            isAttacking = false;
            _attackTimerController = true;
        }
        
        /// <summary>
        /// Move enemy with rigid-body, if "isAttacking" is false
        /// </summary>
        private void MoveEnemy()
        {
            if (!isAttacking)
            {
                _enemyMovement.MoveEnemy(this);
            }
        }
        
        private void RotateEnemy()
        {
            _enemyMovement.RotateEnemy(this);   
        }
        
        
        /// <summary>
        /// Reduce health of enemy with player damage
        /// </summary>
        /// <param name="playerDamage"></param>
        public void ReduceHealth(float playerDamage)
        {
            //Assign health bar value
            _enemyHealthBar.value -= playerDamage;
            
            //Play Effect
            _effectManager.PlayEnemyHitEffect(transform);
            
            //Check if dead, if dead move to the pool and increase death count 
            if (_enemyHealthBar.value == 0)
            {
                _effectManager.PlayEnemyDeathEffect(transform);
                deathEnemyCount++;
                MoveToThePool();
            }
        }

        public void MoveToThePool()
        {
           _enemyPooling.MoveEnemyToPool(this); 
           isInPool = true;
        }

        public void ReturnFromPool()
        {
            _enemyPooling.ReturnEnemyFromPool(this);
            isInPool = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //TODO: Reduce Player Health
                _playerHeal.ReduceHealth(damage-1);
                
                //TODO: Enemy Player Attack Animation
            }

            if (other.gameObject.CompareTag("Fence"))
            {
                //TODO: Reduce Fence Shield
                
                //TODO: Enemy Fence Attack Animation
            }
        }
    }
}

