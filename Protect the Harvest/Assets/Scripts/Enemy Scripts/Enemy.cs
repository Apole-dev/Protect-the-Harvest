using System;
using System.Collections;
using System.Globalization;
using Interfaces;
using Managers;
using Player_Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour , IEnemy
    {
        #region Enemy General Acsseser
        public static int deathEnemyCount;
        public Material hitMaterial;
        public bool isAttacking;
        public bool isInPool;
        #endregion
        
        
        #region Enemy Out Line Properties
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public int FireRate { get; set; }
        public Rigidbody EnemyRigidBody { get; private set; }
        #endregion

        
        #region Enemy Object Acsseser

        private ParticleCollisionDetector _particleCollisionDetector;
        private Slider _enemyHealthBar;
        private bool _attackTimerController = true;
        private SkinnedMeshRenderer[] _hitPart ;
        private TMP_Text _hitText;
        private bool _isCollidingWithFence;
        private bool _isHittingPlayer;
        
        //Scripts
        private EnemyMovement _enemyMovement;
        private EnemyAttack _enemyAttack;
        private EffectManager _effectManager;
        private EnemyPooling _enemyPooling;
        private PlayerHeal _playerHeal;
        private Fence _fence;
        
        #endregion


        #region Unity Callbacks
        

        private void OnEnable()
        {
            _enemyHealthBar.value = Health;
            ChangeColor();
        }
        private void OnDisable()
        {
            _isCollidingWithFence = false;
        }
        
        private void Awake()
        {
            _hitPart = GetComponentsInChildren<SkinnedMeshRenderer>();
            _hitText = GetComponentInChildren<TMP_Text>();
            
            _particleCollisionDetector = FindObjectOfType<ParticleCollisionDetector>();
            _enemyMovement = FindObjectOfType<EnemyMovement>();
            _effectManager = FindObjectOfType<EffectManager>();
            _enemyAttack = FindObjectOfType<EnemyAttack>();
            _enemyPooling = FindObjectOfType<EnemyPooling>();
            _playerHeal = FindObjectOfType<PlayerHeal>();
            _fence = FindObjectOfType<Fence>();
            
            EnemyRigidBody = GetComponent<Rigidbody>();
            _enemyHealthBar = GetComponentInChildren<Slider>();
         
            
            isAttacking = false;
        }


        private void Start()
        {
            _hitText.gameObject.SetActive(false); 

            _enemyHealthBar.maxValue = Health;
            _enemyHealthBar.value = Health;
        }
        
        private void Update()
        {
            Attack();
            print(_isCollidingWithFence);
        }

        private void FixedUpdate()
        {
            MoveEnemy();
            RotateEnemy();
        }
        
        #endregion


        #region Attack & Health
        
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
                _enemyAttack.Attack(Damage);
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
            yield return new WaitForSeconds(FireRate);
            isAttacking = false;
            _attackTimerController = true;
        }
        
        
        public void ReduceHealth(float playerDamage)
        {
            //Assign health bar value
            _enemyHealthBar.value -= playerDamage;
            
            //Play Effect
            _effectManager.PlayEnemyHitEffect(transform);
            
            //Check if dead, if dead move to the pool and increase death count 
            if (_enemyHealthBar.value != 0) return;
            
            _effectManager.PlayEnemyDeathEffect(transform);
            deathEnemyCount++;
            MoveToThePool();
        }

        private void AttackFence()
        {
            _fence.ReduceShield(Damage);
        }
        
        private IEnumerator AttackFenceTimer()
        {
            while (_isCollidingWithFence)
            {
                AttackFence();
                yield return new WaitForSeconds(2f);
            }
        }
        
        private IEnumerator ReducePlayerHealth()
        {
            while (_isHittingPlayer)
            {
                _playerHeal.ReduceHealth(Damage* Time.deltaTime);
                yield return new WaitForSeconds(10f);
            }
        }
        

        #endregion
        

        #region Movement & Rotation
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
        
        #endregion
        

        #region Push Back

        public void PushBack(float pushAmount)
        {
            if (!gameObject.activeSelf) return;
            
            StartCoroutine(PushBackTimer(pushAmount));
        }
        private IEnumerator PushBackTimer(float pushAmount)
        {
            for (float time = 0; time < 0.1f; time += Time.deltaTime)
            {
                EnemyRigidBody.AddForce(Vector3.forward *pushAmount);
                yield return null;
            }
        }

        #endregion
        

        #region Hit Color Effect

        public void ChangeColor()
        {
            foreach (var part in _hitPart)
            {
                if (!gameObject.activeSelf) break;
                var oldPartMaterial = part.material;
                StartCoroutine(ResetMaterialOfEnemy(part, oldPartMaterial));
            }
        }

        public void HitText(float duration, float playerDamage, Color color)
        {
            if (!gameObject.activeSelf) return;
            
            _hitText.gameObject.SetActive(true);
           _hitText.text = playerDamage.ToString(CultureInfo.InvariantCulture);
           _hitText.color = color;
           StartCoroutine(ReSizeText(duration));
        }

        private IEnumerator ReSizeText(float duration )
        {
            float elapsedTime = 0f;
    
            while (elapsedTime < duration)
            {
                _hitText.transform.localScale = Vector3.Lerp(Vector3.one * 10, Vector3.zero, elapsedTime / duration);
                elapsedTime += Time.deltaTime;

                yield return null;
            }
            
            _hitText.gameObject.SetActive(false);
        }

        private IEnumerator ResetMaterialOfEnemy(SkinnedMeshRenderer part, Material oldPart)
        { 
            part.material = hitMaterial;
            yield return new WaitForSeconds(2f);
            // ReSharper disable once Unity.InefficientPropertyAccess
            part.material = oldPart;
        }
        
        #endregion


        #region Pooling
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

        #endregion


        #region Unity Functions
        
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                //TODO: Reduce Player Health
                _isHittingPlayer = true;
                if (_isHittingPlayer)
                {
                    StartCoroutine(ReducePlayerHealth());
                }
                
                //TODO: Enemy Player Attack Animation
            }

            if (other.gameObject.CompareTag("Fence"))
            {
                //TODO: Reduce Fence Shield
                _isCollidingWithFence = true;
                if (_isCollidingWithFence)
                {
                    StartCoroutine(AttackFenceTimer());
                }
                //TODO: Enemy Fence Attack Animation
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Fence"))
            {
                _isCollidingWithFence = false;
                StopCoroutine(AttackFenceTimer());
            }

            if (other.gameObject.CompareTag("Player"))
            {
                _isHittingPlayer = false;
                StopCoroutine(ReducePlayerHealth());
            }
        }

        #endregion
    }
}

