using System.Collections.Generic;
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
            foreach (var enemyScript in enemyGenerator.enemyScriptList)
            {
                switch (enemyScript.isInPool)
                {
                    case true:
                        enemyGenerator.enemyPropertiesList.Remove(enemyScript.enemyProperties);
                        break;
                    case false when !enemyGenerator.enemyPropertiesList.Contains(enemyScript.enemyProperties):
                        enemyGenerator.enemyPropertiesList.Add(enemyScript.enemyProperties);
                        break;
                }
            }

            foreach (var enemyProperties in enemyGenerator.enemyPropertiesList)
            {
                MoveEnemy(enemyProperties);
                RotateEnemy(enemyProperties);
            }
        }
        
        private void MoveEnemy(EnemyProperties enemyProperties)
        {
            var direction = (playerGameObject.transform.position - enemyProperties.enemyPrefab.transform.position);
            enemyProperties.enemyPrefabRigidBody.velocity = direction.normalized * (Time.fixedDeltaTime * enemyProperties.moveSpeed * 10f);
        }

        private void MoveEnemy(GameObject enemyObject,Rigidbody rb,bool isInPool = false)
        {
            var direction = (playerGameObject.transform.position - enemyObject.transform.position);
            rb.velocity = direction.normalized * (Time.fixedDeltaTime * enemyObject.GetComponent<Enemy>().moveSpeed * 10f);
        }
        
        private void RotateEnemy(EnemyProperties enemyProperties)
        {
            var playerPosition = -playerGameObject.transform.position;
            enemyProperties.enemyPrefab.transform.LookAt(playerPosition*turnSpeed);
        }

        private void RotateEnemy(GameObject enemyObject)
        {
            var playerPosition = -playerGameObject.transform.position;
            enemyObject.transform.LookAt(playerPosition*turnSpeed);
        }
    }
}