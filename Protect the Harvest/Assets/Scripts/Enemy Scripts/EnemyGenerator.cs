using UnityEngine;
using Singleton;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyGenerator : MonoBehaviour
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

        public int EnemyCount{ get; private set; }
        [SerializeField] private Material hitMaterial;
        
        #endregion

        #region Enemy Generation
        
        public void InstantiateEnemyWithCount(int enemiesCount)
        {
            for (int i = 0; i < enemiesCount; i++)
            {
                InstantiateEnemy();
            }
        }
        
        private void InstantiateEnemy()
        {
            // Positioning & Spawning
            Vector3 randomPosition = GenerateRandomEnemyPosition(centerOfEnemyArea.position, swWidth: spawnWidth, swHeight: spawnHeight);
            enemyClone = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Setup
            SetupEnemy(enemyClone);
        }
        
        
        private void SetupEnemy(GameObject enemy)
        {
            
            enemy.tag = "Enemy";
            enemy.name = "Enemy Clone " + EnemyCount++;
            Enemy enemyScript = enemy.AddComponent<Enemy>();
            
            enemyScript.Damage = EnemyRandomData.Instance.GetRandomDamage();
            enemyScript.FireRate = EnemyRandomData.Instance.GetRandomFireRate();
            enemyScript.Speed = EnemyRandomData.Instance.GetRandomSpeed();
            enemyScript.Health = EnemyRandomData.Instance.GetRandomHealth();
            enemyScript.hitMaterial = hitMaterial;
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
