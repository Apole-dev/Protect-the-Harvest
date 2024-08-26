using System;
using System.Collections;
using Enemy_Scripts.Our_Enemy.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemy_Scripts.Our_Enemy.Witcher
{
    [RequireComponent(typeof(Rigidbody))]
    public class Witcher : MonoBehaviour,IOurEnemyHealth ,IOurEnemyAttack,IOurEnemyMovement,IOurEnemyHit
    {
        [Header("Stats")]
        [SerializeField] [Range(60,100)] private float health;
        [SerializeField] [Range(5,100)] private float moveSpeed;
        [SerializeField] [Range(0,1)] private float attackSpeed;
        [SerializeField] [Range(25,100)] private float rotationSpeed;
        [SerializeField] [Range(0,10)] private float damage;
        
        [Header("Script References")]
        [SerializeField] private OurEnemyMovement ourEnemyMovement;
        [SerializeField] private OurEnemyHit ourEnemyHit;
        [SerializeField] private OurEnemyAttack ourEnemyAttack;
        [SerializeField] private OurEnemyHealth ourEnemyHealth;
        [SerializeField] private OurEnemyPooling ourEnemyPooling;
        [FormerlySerializedAs("ourEnemyManger")] [SerializeField] private OurEnemyManager ourEnemyManager;
        [SerializeField] private HitController hitController;
        
        [Header("Components")]
        [SerializeField] private Rigidbody rigidBody;


        [Header("Characteristics")] 
        [SerializeField] private GameObject shootGameObject;
        
        [Header("Activation Controllers")]
        public bool moveActive;
        public bool rotateActive; [Space]
        public bool updateHealthActive;
        public bool resetHealthActive;[Space]
        public bool deathActive;[Space]
        public bool attackActive;
        public bool stopAttackActive;
        public bool resetAttackActive;[Space]
        public bool takeDamageActive;
        public bool pushBackActive;
        
        
        
        private GameObject _target;
        private Vector3 _targetTempTransformPosition;
        private float _time;
        
        
        #region MonoBehaviour

        private void Update()
        {
            if (health == 0)
            {
                //ourEnemyPooling.AddOurEnemyToPool(gameObject);
            }
        }
        
        private void FixedUpdate()
        {
            _target = GameObject.FindGameObjectWithTag("Player");
            Move();
            Rotate();
        }

        // private void OnDisable()
        // {
        //     StopAllCoroutines();
        //     ourEnemyPooling.AddOurEnemyToPool(gameObject);
        //     
        //     ourEnemyManager.deadCount++;
        // }

        #endregion
        
        #region Movement

        public void Move()
        {
            if(moveActive == false) return;
            ourEnemyMovement.OurEnemyMove(gameObject,_target,rigidBody,moveSpeed);
        }

        public void Rotate()
        {
            if(rotateActive == false) return;
            ourEnemyMovement.OurEnemyRotate(gameObject,_target,rotationSpeed);
        }

        public void Stop()
        {
            moveActive = false;
            ourEnemyMovement.OurEnemyStop(rigidBody);
            //StartCoroutine(ReMove());
            
        }

        private IEnumerator ReMove() //For stopping movement after attack
        {
            yield return new WaitForSeconds(3f);
            moveActive = true;
            _time = 0; 
        }
        
        #endregion

        #region Hit

        public void TakeDamage(float damage)
        {
            
            if (!takeDamageActive) return;
            print("Witcher Take Damage");
            
            float newHealth =  ourEnemyHit.TakeDamage(health,damage);
            health = newHealth;
            
        }

        public void PushBack(float pushAmount)
        {
            if (!pushBackActive) return;
            print("Witcher Push Back");
            
            ourEnemyHit.PushBack(rigidBody,pushAmount);
            
        }

        #endregion

        #region Health
        
        public void UpdateHealth(float currentHealth, float healAmount)
        {
            if (!updateHealthActive) return;
            print("Witcher Health Updated");
            
            float newHealth = ourEnemyHealth.UpdateHealth(currentHealth,healAmount);
            health = newHealth;
        }

        public void ResetHealth(float currentHealth)
        {
            if (!resetHealthActive) return;
            print("Witcher Health Reset");
            
            float newHealth = ourEnemyHealth.ResetHealth(currentHealth);
            health = newHealth;
        }

        public void Death()
        {
            if (!deathActive) return;
            print("Witcher Dead");
            
            //ourEnemyHealth.Death();
            gameObject.SetActive(false);
        }
        #endregion

        #region Attack
        public void Attack()
        {
            if (!attackActive) return;
            print("Witcher Attack");
            var hitToTarget = hitController.GetHitGameObject();
            
            
            _time += Time.deltaTime;
            if (_time >= 1/attackSpeed)
            {
                _time = 0;
                Stop(); //Stop moving while attacking
                StartCoroutine(WaitBeforeAssignValueOfTarget());
                
            
                if(hitToTarget) ourEnemyAttack.Attack((int)damage); //Reduce Health of player
            }
            
        }
        


        public void StopAttack()
        {
            if (!stopAttackActive) return;
            print("Witcher Attack Stopped");
        }

        public void ResetAttack()
        {
            if (!resetAttackActive) return;
            print(" Witcher Attack Reset");
        }
        #endregion

        #region Temp Target Transform Assigner
        
        private IEnumerator WaitBeforeAssignValueOfTarget()
        {
            _targetTempTransformPosition = _target.transform.position;
            yield return new WaitForSeconds(0.5f); // To prevent instant hit to target
            shootGameObject.transform.position = _targetTempTransformPosition;
        }
        #endregion

    }
}