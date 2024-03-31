using System;
using System.Collections;
using Enums;
using Interfaces;
using Singleton;
using UnityEngine;


namespace Player_Scripts
{
    public class PlayerAttack : MonoSingleton<PlayerAttack>
    {
        [Header("Scripts Accessors")]
        [SerializeField] private Inventory playerInventory;

        [SerializeField] private GameObject shootPoint;

        [Space]

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
        public GameObject enemyGameObject;
        public GunType currentGunType;
        public int currentDamage;
        public int currentRange;
       
        
        private IEnemy _enemy;
        private bool _isHitEnemy;
        private bool _attackActive = false;


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
            PlayShootByType(shootPoint.transform,transform, _isHitEnemy);
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
            
        }
        

        private void PlayShootByType(Transform playerShootPoint, Transform enemyShootPoint,bool isHitEnemy)
        {
            
            playerInventory.selectedWeapon.PlayerShootPoint = playerShootPoint;
            playerInventory.selectedWeapon.EnemyShootPoint = enemyShootPoint;
            playerInventory.selectedWeapon.Shoot(isHitEnemy);
            print("PlayShootByType called");
        }


        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(transform.position, 1f);
        }

        #region Line Renderer Methods

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
        
        #endregion
    }
}
