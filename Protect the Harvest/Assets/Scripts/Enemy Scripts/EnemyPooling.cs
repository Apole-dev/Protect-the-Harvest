using System.Collections.Generic;
using Singleton;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy_Scripts
{
    public class EnemyPooling : MonoSingleton<EnemyPooling>
    {
        [SerializeField] private Transform poolPlace;
        [SerializeField] private Transform enemyInstantiatePlace;
        
        public readonly List<Enemy> enemiesScriptInPool = new List<Enemy>();
        public int tempEnemyScriptInPool;

        public void MoveEnemyToPool(Enemy enemyObjectScript)
        { 
            if(enemyObjectScript == null) return;
            
            enemiesScriptInPool.Add(enemyObjectScript);
            Vector3 position = poolPlace.position;
            enemyObjectScript.transform.position = new Vector3(position.x +Random.Range(-1f,1f), position.y, position.z +Random.Range(-1f,1f));
            enemyObjectScript.GameObject().SetActive(false);
            enemyObjectScript.isInPool = true;
        }
        
        public void ReturnEnemyFromPool(Enemy enemyObjectScript)
        {
            if(enemyObjectScript == null) return;
            tempEnemyScriptInPool = enemiesScriptInPool.Count;
            
            enemiesScriptInPool.Remove(enemyObjectScript);
            Vector3 position = enemyInstantiatePlace.position;
            enemyObjectScript.transform.position = new Vector3(position.x +Random.Range(-1f,1f), position.y, position.z +Random.Range(-1f,1f));
            enemyObjectScript.GameObject().SetActive(true);
            enemyObjectScript.isInPool = false;
        }
        
    }
}