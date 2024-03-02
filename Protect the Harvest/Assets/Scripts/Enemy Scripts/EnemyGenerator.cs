using System;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyGenerator : MonoSingleton<EnemyGenerator>
    {
        #region Variables
        
        // Spawn parameters
        [Header("Spawn Parameters")]
        [SerializeField] private float spawnHeight = 0.5f;
        [SerializeField] private float spawnWidth = 5f;

        // Prefabs and transforms
        [Header("Prefab and Transforms")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform centerOfEnemyArea;
        [SerializeField] private Transform centerOfSafeArea;
        
        public GameObject enemyClone;
        [SerializeField] private StageCombatController stageCombatController;
        
        // Lists to store enemies and their properties
        public readonly List<EnemyProperties> enemyPropertiesList = new List<EnemyProperties>();
        public readonly List<Enemy> enemyScriptList = new List<Enemy>();
        
        
        #endregion

        #region Enemy Generation

        private void Start()
        {
            //first spawn
            InstantiateEnemyWithCount(3);
        }

        private void InstantiateEnemy()
        {
            // Positioning & Spawning
            Vector3 randomPosition = GenerateRandomEnemyPosition(centerOfEnemyArea.position, swWidth: spawnWidth, swHeight: spawnHeight);
            enemyClone = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Setup
            SetupEnemy(enemyClone);
        }
        
        public void InstantiateEnemyWithCount(int enemiesCount)
        {
            for (int i = 0; i <= enemiesCount; i++)
            {
                InstantiateEnemy();
            }
        }


        
        private void SetupEnemy(GameObject enemy)
        {
            enemy.tag = "Enemy";
            enemy.name = "Enemy Clone " + EnemyProperties.enemiesCount;
            
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScriptList.Add(enemyScript);
            enemyScript.moveSpeed = EnemyRandomData.Instance.GetRandomSpeed();
            enemyScript.health = EnemyRandomData.Instance.GetRandomHealth();
            enemyScript.damage = EnemyRandomData.Instance.GetRandomDamage();

            EnemyProperties enemyProperties = new EnemyProperties(enemy, enemy.GetComponent<Rigidbody>(), enemyScript.moveSpeed, enemyScript.health, enemyScript.damage);
            enemyScript.enemyProperties = enemyProperties;
            enemyPropertiesList.Add(enemyProperties);
            
        }
        
        #endregion

        #region Utility Methods
        private Vector3 GenerateRandomEnemyPosition(Vector3 objectPosition, float swHeight, float swWidth)
        {
            spawnWidth = swWidth;
            spawnHeight = swHeight;

            float randomX = Random.Range(objectPosition.x - swWidth, objectPosition.x + swWidth);
            float randomZ = Random.Range(objectPosition.z - swHeight, objectPosition.z + swHeight);

            return new Vector3(randomX + 0.5f, objectPosition.y, randomZ + 0.5f);
        }


        #endregion
        
    }
}
