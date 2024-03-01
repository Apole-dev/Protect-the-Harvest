using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{
    public class EnemyProperties
    {
        public static int enemiesCount = 0;
        
        public readonly GameObject enemyPrefab;
        public readonly Rigidbody enemyPrefabRigidBody;
        public readonly float moveSpeed;
        public readonly float health;
        public readonly float damage;

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