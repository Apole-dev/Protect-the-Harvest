using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Singleton;
using Unity.VisualScripting;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyGenerator : MonoSingleton<EnemyGenerator>
    {
        #region Variables
        // Components
        
        // Spawn parameters
        [Header("Spawn Parameters")]
        [SerializeField] private float spawnHeight = 0.5f;
        [SerializeField] private float spawnWidth = 5f;

        // Prefabs and transforms
        [Header("Prefab and Transforms")]
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform centerOfEnemyArea;
        [SerializeField] private Transform centerOfSafeArea;

        // Control variables
        public static float enemiesLimitNum = 2f;
        private int _tempEnemiesCount = 0;

        public bool isEnemyCountChanged = false;
        private bool _spawnLimitController = false;

        public GameObject enemyClone;
        private StageCombatController _stageCombatController;
        
        // Lists to store enemies and their properties
        public readonly List<EnemyProperties> enemyPropertiesList = new List<EnemyProperties>();
        
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            // Initialize components
            _stageCombatController = FindObjectOfType<StageCombatController>();
        }
        
        #endregion

        #region Enemy Generation
        public void InstantiateEnemy()
        {
            //If spawn limit controller 
            if (_spawnLimitController) return;

            // Positioning
            Vector3 randomPosition = GenerateRandomEnemyPosition(centerOfEnemyArea.position, swWidth: spawnWidth, swHeight: spawnHeight);

            // Spawning
            _tempEnemiesCount = EnemyProperties.enemiesCount;
            enemyClone = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Setup
            SetupEnemy(enemyClone);
           

            // Check spawn limit
            if (EnemyProperties.enemiesCount >= enemiesLimitNum)
            {
                print("Maximum enemy count reached");
                _spawnLimitController = true;
            }
            else
            {
                _spawnLimitController = false;
            }

            // Check if enemy count has changed
            if (_tempEnemiesCount < EnemyProperties.enemiesCount)
            {
                isEnemyCountChanged = true;
            }

            // Reset spawn limit controller if stage is passed
            if (_stageCombatController.isStagePassed)                                                                             
            {
                print("StageCombatController.isStagePassed is active");
                _spawnLimitController = false;
            }
            
            print(EnemyProperties.enemiesCount);
            
        }
        
        private void SetupEnemy(GameObject enemy)
        {
            enemy.tag = "Enemy";
            enemy.name = "Enemy Clone " + EnemyProperties.enemiesCount;
            
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.moveSpeed = EnemyRandomData.Instance.GetRandomSpeed();
            enemyScript.health = EnemyRandomData.Instance.GetRandomHealth();
            enemyScript.damage = EnemyRandomData.Instance.GetRandomDamage();

            EnemyProperties enemyProperties = new EnemyProperties(enemy, enemy.GetComponent<Rigidbody>(), enemyScript.moveSpeed, enemyScript.health, enemyScript.damage);
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
