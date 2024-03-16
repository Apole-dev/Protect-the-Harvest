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
            if (!_isHitEnemy) return;
                                    
            PlayShootByType(transform, enemyGameObject.transform, _isHitEnemy);
            var component = enemyGameObject.GetComponent<IEnemy>();
            component.ReduceHealth(playerDamage:currentDamage);//TODO
            component.PushBack(300f);
            component.ChangeColor();
            component.HitText(0.2f,currentDamage,Color.yellow);
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
                //REFACTOR WE DONT NEED TO ALSO ADD IF SECTION MASK ALREADY IMITATED
                
                //Assign the color when it hit
                lineRenderer.material.color = hitColor;

                //Check if the hit object is an enemy
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    //Set the gunShootDistance to the hit distance
                    gunShootDistance = hit.distance;
                    
                    //Set the hit value
                    _isHitEnemy = true;
                    
                    //Set the enemy
                    enemyGameObject = hit.collider.gameObject; 
                }
            }
            else
            {
                //Assign the color when it not hit
                lineRenderer.material.color = notHitColor;
                
                //Reset the gunShootDistance turn into old value
                gunShootDistance = currentGunType.GetHashCode();
                
                //Reset the hit value
                _isHitEnemy = false;
            }

            #endregion
        }
        

        private void PlayShootByType(Transform playerShootPoint, Transform enemyShootPoint,bool isHitEnemy)
        {
            
            playerInventory.selectedWeapon.PlayerShootPoint = playerShootPoint;
            playerInventory.selectedWeapon.EnemyShootPoint = enemyShootPoint;
            playerInventory.selectedWeapon.Shoot(isHitEnemy);
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
