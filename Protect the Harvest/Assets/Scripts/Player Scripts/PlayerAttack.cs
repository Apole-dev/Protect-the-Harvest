using System;
using System.Collections;
using Enemy_Scripts;
using Enums;
using UnityEngine;


namespace Player_Scripts
{
    public class PlayerAttack : MonoBehaviour
    {
        #region General Acsessers

        [Header("General Accessors")] 
        public static bool stagePassed;
        
        #endregion
        
        #region Scripts Accessers
        [Header("Scripts Accessors")]
        private EnemyHealth _enemyHealth;
        [SerializeField] private Inventory playerInventory;
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
        #endregion
        
        private void Update()
        {
            if (ButtonPressController.isPressed && _enemyGameObject != null)
            {
                Attack();
            }
        }

        private void Attack()
        {
            StartCoroutine(PlayShootEffect());

            if (_isHit)
            {
                _enemyHealth.ReduceHealth(_attackDamage);
            }
        }
        
        private IEnumerator PlayShootEffect() //Shoot effect playing 1 more time. FIXME need to be fixed
        {
            yield return new WaitForSeconds(0.5f);
            shootEffect.Play();
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
                _enemyGameObject = hit.collider.gameObject;
                _enemyHealth = _enemyGameObject.transform.GetComponentInChildren<EnemyHealth>();
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
