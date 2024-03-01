using System;
using System.Collections;
using System.Diagnostics;
using Enemy_Scripts;
using Enums;
using Interfaces;
using Singleton;
using UnityEngine;
using UnityEngine.UI;


namespace Player_Scripts
{
    public class PlayerAttack : MonoSingleton<PlayerAttack>
    {
        #region General Acsessers

        [Header("General Accessors")] 
        public static bool stagePassed;
        
        #endregion
        
        #region Scripts Accessers
        [Header("Scripts Accessors")]
        [SerializeField] private Inventory playerInventory;
        
        private IEnemy _enemy;
        #endregion
        
        #region Line Renderer Settings
        [Space]
        
        [Header("Line Renderer Settings")]
        [Range(0.1f, 0.5f)] [SerializeField] private float startWidth = 0.3f;
        [Range(0.1f, 0.5f)] [SerializeField] private float endWidth = 0.1f;
        [SerializeField] private LayerMask enemyMask;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float gunShootDistance = 5f;
        
        private GunType _currentGunType;
        #endregion

        #region Player Attributes
        [Space]
        
        [Header("Player Attributes")]
        [SerializeField] private Animator animator;

        private GameObject _enemyGameObject;
        private float _attackDamage;
        #endregion

        #region Shoot Effect
        [Space]
        
        [Header("Shoot Effect")]
        [SerializeField] private ParticleSystem shootEffect;
        private bool _isHit;
        private bool _shootEffectPlaying = false;
        private bool _attackActive = false;
        #endregion
        
        private void Update()
        {
            if (ButtonPressController.isPressed && _enemyGameObject != null)
            {
                StartCoroutine(AttackInRate());
            }

            if (ButtonPressController.isPressed)
            {
                StartCoroutine(PlayShootEffect());
            }
        }

        private void Attack()
        {
            if (_isHit)
                _enemyGameObject.GetComponent<IEnemy>().ReduceHealth(playerDamage: _attackDamage);
        }
        
        private IEnumerator PlayShootEffect() //Shoot effect playing 1 more time. FIXME need to be fixed
        {
            // if (!_shootEffectPlaying)
            // {
            //     _shootEffectPlaying = true;
            //     yield return new WaitForSeconds(0.5f);
            //     shootEffect.Play();
            //     _shootEffectPlaying = false;
            // }
            yield return new WaitForSeconds(0.5f);
            shootEffect.Play();
        }
        
        private IEnumerator AttackInRate()
        {
            if (!_attackActive)
            {
                _attackActive = true;
                yield return new WaitForSeconds(0.5F);
                Attack();
                _attackActive = false;
            }
        }


        public void DrawWeaponShootLine()
        {
            #region Line Draw
            
            ConfigureLineRenderer();
            var origin = transform.position + new Vector3(0, 1, 0);
            var transformDirection = transform.TransformDirection(Vector3.forward);
            DrawLine(origin, origin + transformDirection * gunShootDistance); 
            
            #endregion

            #region Player Properties
            
            _currentGunType = playerInventory.gunType;
            gunShootDistance = (int)_currentGunType;
            print("PlayerAttack.cs | Gun Type: " + _currentGunType);

            var tempShootDistance = gunShootDistance;
            print("PlayerAttack.cs | Gun Shoot Distance: " + gunShootDistance);
            
            _attackDamage = playerInventory.chosenDamage;
            print("PlayerAttack.cs | Attack Damage: " + _attackDamage);
            
            #endregion

            #region Raycast
            
            if (Physics.Raycast(origin, transformDirection, out var hit, gunShootDistance, enemyMask))
            {
                //Assign the enemy game object
                _enemyGameObject = hit.collider.gameObject;
                
                //Assign the color when it hit
                lineRenderer.material.color = Color.green;

                //Check if the hit object is an enemy
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    //Set the gunShootDistance to the hit distance
                    gunShootDistance = hit.distance;
                    _isHit = true;
                }
                
                //If the hit object is a spawn manger object then stop the attack for that object because it is a manger of the enemies
                if(hit.collider.gameObject.CompareTag("Spawn Manger Object"))
                    _isHit = false;
            }
            else
            {
                //Assign the color when it not hit
                lineRenderer.material.color = Color.white;
                
                //Reset the gunShootDistance
                gunShootDistance = tempShootDistance;
                
                _isHit = false;
            }

            

            #endregion
        }
        
        

        /// <summary>
        /// Configures the line renderer
        /// </summary>
        private void ConfigureLineRenderer()
        {
            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
        }

        /// <summary>
        /// Draws the line renderer from start to end
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private void DrawLine(Vector3 start, Vector3 end)
        {
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
        
    }
}
