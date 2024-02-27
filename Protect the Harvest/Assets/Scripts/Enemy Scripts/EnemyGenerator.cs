using System.Collections.Generic;
using Singleton;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyGenerator : MonoSingleton<EnemyGenerator>
    {
        [SerializeField] private float spawnHeight = 0.5f;
        [SerializeField] private float spawnWidth = 5f;
        
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Transform centerOfEnemyArea;
        [SerializeField] private Transform centerOfSafeArea;

        private readonly List<GameObject> _enemies = new List<GameObject>();
        private bool _spawnLimitController = true;

        public static float enemiesLimitNum = 5f;


        public void InstantiateEnemy()
        {
            if (_spawnLimitController)
            {
                var randomPosition = GenerateRandomEnemyPosition(centerOfEnemyArea.position);
                var newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

                SetupEnemy(newEnemy);
                _enemies.Add(newEnemy);

                if (_enemies.Count >= enemiesLimitNum )
                {
                    print("Maximum enemy count reached");
                    _spawnLimitController = false;
                }
            }

        }

        private Vector3 GenerateRandomEnemyPosition(Vector3 objectPosition, float spawnHeight = 0.5f, float spawnWidth = 5f)
        {
            this.spawnWidth = spawnWidth;
            this.spawnHeight = spawnHeight;
            
            var randomX = Random.Range(objectPosition.x - spawnWidth, objectPosition.x + spawnWidth);
            var randomZ = Random.Range(objectPosition.z - spawnHeight, objectPosition.z + spawnHeight);

            return new Vector3(randomX + 0.5f, objectPosition.y, randomZ + 0.5f);
        }

        private void SetupEnemy(GameObject enemy)
        {
            enemy.tag = "Enemy";
            enemy.name = "Enemy Clone";

            // Assuming the child objects exist, disable them
            Transform childTransform = enemy.transform.GetChild(0);
            if (childTransform != null)
            {
                childTransform.gameObject.SetActive(false);
            }
            
        }

        public void MoveToSafeArea(GameObject enemy,bool enemySituation)
        {
            if (enemySituation)
            {
                enemy.transform.position = GenerateRandomEnemyPosition(centerOfSafeArea.position,1f,10f);
            }
        }
    }
}
