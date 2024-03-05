using System.Collections;
using System.Globalization;
using Enums;
using Interfaces;
using Managers;
using Singleton;
using TMPro;
using UnityEngine;



namespace Player_Scripts
{
    public class PlayerAttack : MonoSingleton<PlayerAttack>
    {
        
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
        [SerializeField] private EffectManager effectManager;

        private GameObject _enemyGameObject;
        public int currentAttackDamage { get; private set; }
        #endregion

        #region Shoot Effect
        [Space]
        
        [Header("Shoot Effect")]
        private bool _isHit;
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
          

        #region Attack Section
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
        private void Attack()
        {
            if (_isHit) _enemyGameObject.GetComponent<IEnemy>().ReduceHealth(playerDamage: currentAttackDamage);
        }
        
        /// <summary>
        /// Plays the shoot effect
        /// </summary>
        /// <returns></returns>
        private IEnumerator PlayShootEffect() //Shoot effect playing 1 more time. FIXME need to be fixed
        {
            yield return new WaitForSeconds(0.5f);
            effectManager.PlayPlayerAttackEffect();
        }

        #endregion



        public void DrawWeaponShootLine()
        {
            #region Line Draw
            
            ConfigureLineRenderer();
            var origin = transform.position + new Vector3(0, 1, 0);
            var transformDirection = transform.TransformDirection(Vector3.forward);
            DrawLine(origin, origin + transformDirection * gunShootDistance); 
            
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
                gunShootDistance = _currentGunType.GetHashCode();
                
                _isHit = false;
            }

            

            #endregion
        }


        public void AssignGun(GunType newGunType, int newDamage)
        {
            _currentGunType = newGunType;
            gunShootDistance = (int)_currentGunType;
            currentAttackDamage = newDamage;
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
