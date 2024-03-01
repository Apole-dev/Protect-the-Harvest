using System;
using Interfaces;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private float turnSpeed = 100f;

        // ReSharper disable once InconsistentNaming
        private EnemyGenerator enemyGenerator;

        private void Awake() => enemyGenerator = EnemyGenerator.Instance;

        private void FixedUpdate() => AllEnemiesMove();
        
        
        private void AllEnemiesMove()
        {
            try
            {
                for (int i = 0; i < EnemyProperties.enemiesCount; i++)
                {
                    MoveEnemy(enemyGenerator.enemyPropertiesList[i]);
                    EnemyRotate(enemyGenerator.enemyPropertiesList[i]);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        
        private void MoveEnemy(EnemyProperties enemyProperties)
        {
            var direction = (playerGameObject.transform.position - enemyProperties.enemyPrefab.transform.position);
            enemyProperties.enemyPrefabRigidBody.velocity = direction.normalized * (Time.fixedDeltaTime * enemyProperties.moveSpeed * 50f);
        }
        
        private void EnemyRotate(EnemyProperties enemyProperties)
        {
            var playerPosition = -playerGameObject.transform.position;
            enemyProperties.enemyPrefab.transform.LookAt(playerPosition*turnSpeed);
        }
    }
}