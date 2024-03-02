using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{
    public class EnemyProperties
    {
        public static int enemiesCount = 0;
        public bool isInPool;
        public GameObject enemyPrefab{get; private set;}
        public Rigidbody enemyPrefabRigidBody {get; private set;}
        public float moveSpeed {get; private set;}
        public float health {get; private set;}
        public float damage {get; private set;}

        public EnemyProperties(GameObject enemyPrefab, Rigidbody enemyPrefabRigidBody, float moveSpeed, float health, float damage)
        {
            enemiesCount ++;
            
            this.enemyPrefab = enemyPrefab;
            this.enemyPrefabRigidBody = enemyPrefabRigidBody;
            this.moveSpeed = moveSpeed;
            this.health = health;
            this.damage = damage;
        }
    }
}