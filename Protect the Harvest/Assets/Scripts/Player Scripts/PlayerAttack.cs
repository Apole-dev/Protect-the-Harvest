using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Interfaces;
using Managers;
using Player_Scripts.Weapons;
using Singleton;
using UnityEngine;


namespace Player_Scripts
{
    public class PlayerAttack : MonoSingleton<PlayerAttack>
    {
        
        #region Inspector Fields

        [Header("Scripts Accessors")]
        [SerializeField] private Inventory playerInventory;

        [Header("Line Renderer Settings")]
        [Range(0.1f, 0.5f)] [SerializeField] private float startWidth = 0.3f;
        [Range(0.1f, 0.5f)] [SerializeField] private float endWidth = 0.1f;
        [SerializeField] private LayerMask enemyMask;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private float gunShootDistance = 5f;
        [SerializeField] private Color notHitColor = Color.white;
        [SerializeField] private Color hitColor = Color.green;

        [Space]

        [Header("Player Attributes")]
        [SerializeField] private GameObject enemyGameObject;
        [SerializeField] private GunType currentGunType;

        #endregion

        #region Private Fields

        private IEnemy _enemy;
        private List<Weapon> _weaponsList;
        public int currentAttackDamage { get; private set; }

        [Header("Shoot Effect")]
        private bool _isHit;
        private bool _attackActive = false;

        #endregion

        private void Awake()
        {
            _weaponsList = FindObjectsOfType<MonoBehaviour>().OfType<Weapon>().ToList();
        }

        private void Update()
        {
            if (ButtonPressController.isPressed && enemyGameObject != null)
                StartCoroutine(AttackInRate());
            
            if (ButtonPressController.isPressed)
                StartCoroutine(AttackInRate());
        }
          

        #region Attack Section
        private IEnumerator AttackInRate()
        {
            if (_attackActive) yield break;
            
            _attackActive = true;
            yield return new WaitForSeconds(0.5F);
            _attackActive = false;
            
            Attack();
        }
        private void Attack()
        {
            if (!_isHit) return;
            
            PlayShootByType(transform, enemyGameObject.transform, _isHit);
            var component = enemyGameObject.GetComponent<IEnemy>();
            component.ReduceHealth(playerDamage: currentAttackDamage);
            component.PushBack(300f);
            component.ChangeColor();
            component.HitText(0.2f,currentAttackDamage,Color.yellow);
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
                
                //Assign the color when it hit
                lineRenderer.material.color = hitColor;

                //Check if the hit object is an enemy
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    //Set the gunShootDistance to the hit distance
                    gunShootDistance = hit.distance;
                    
                    //Set the hit value
                    _isHit = true;
                    
                    //Set the enemy
                    enemyGameObject = hit.collider.gameObject;
                }
                
                //If the hit object is a spawn manger object then stop the attack for that object because it is a manger of the enemies
                if(hit.collider.gameObject.CompareTag("Spawn Manger Object")) _isHit = false;
            }
            else
            {
                //Assign the color when it not hit
                lineRenderer.material.color = notHitColor;
                
                //Reset the gunShootDistance turn into old value
                gunShootDistance = currentGunType.GetHashCode();
                
                //Reset the hit value
                _isHit = false;
            }

            

            #endregion
        }


        /// <summary>
        /// Assigns the gun type and damage from the Inventory Script
        /// </summary>
        /// <param name="gunType"></param>
        /// <param name="damage"></param>
        public void AssignGun(GunType gunType, int damage)
        {
            currentGunType = gunType;
            gunShootDistance = (int)currentGunType;
            currentAttackDamage = damage;
        }

        private void PlayShootByType(Transform playerShootPoint, Transform enemyShootPoint,bool isHit)
        {
            playerInventory.selectedWeapon.playerShootPoint = playerShootPoint;
            print("playerInventory.selectedWeapon.playerShootPoint"+playerInventory.selectedWeapon.playerShootPoint);
            playerInventory.selectedWeapon.enemyShootPoint = enemyShootPoint;
            print("playerInventory.selectedWeapon.enemyShootPoint"+playerInventory.selectedWeapon.enemyShootPoint);
            playerInventory.selectedWeapon.Shoot(isHit);
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
