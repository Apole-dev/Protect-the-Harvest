using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyPooling : MonoBehaviour
    {
        [SerializeField] private Transform poolPlace;
        [SerializeField] private Transform enemyInstantiatePlace;
        
        private readonly List<GameObject> _enemiesInPool = new List<GameObject>();

        public void MoveEnemyToPool(GameObject enemyObject)
        { 
            Vector3 position = poolPlace.position;
            enemyObject.transform.position = new Vector3(position.x +Random.Range(-1f,1f), position.y, position.z +Random.Range(-1f,1f));
            enemyObject.SetActive(false);
            
        }
        
        public void MoveEnemyToPool(GameObject enemyObject, int limit)
        {
            _enemiesInPool.Add(enemyObject);
            
            if (limit >= EnemyGenerator.enemiesLimitNum || _enemiesInPool.Count >= limit)
            {
                throw new ArgumentException("Limit must be less than or equal to " + EnemyGenerator.enemiesLimitNum);
            }
            
            Vector3 position = poolPlace.position;
            enemyObject.transform.position = new Vector3(position.x +Random.Range(-1f,1f), position.y, position.z +Random.Range(-1f,1f));
            enemyObject.SetActive(false);
        }

        public void ReturnEnemyFromPool(GameObject enemyObject)
        {
            Vector3 position = enemyInstantiatePlace.position;
            enemyObject.transform.position = new Vector3(position.x +Random.Range(-1f,1f), position.y, position.z +Random.Range(-1f,1f));
            
        }
    }
}