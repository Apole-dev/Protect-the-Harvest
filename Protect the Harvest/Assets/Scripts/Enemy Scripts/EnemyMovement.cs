using Singleton;
using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyMovement : MonoSingleton<EnemyMovement>
    {
        
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private float turnSpeed = 500f;

        public void MoveEnemy(Enemy enemy)
        {
            Vector3 direction = (playerGameObject.transform.position - enemy.transform.position).normalized;
            enemy.enemyRigidBody.velocity = direction * (Time.fixedDeltaTime * enemy.speed * 10f);

            if (Mathf.Abs(enemy.enemyRigidBody.velocity.z) <= 0.15f)
            {
                print("added force due to zero velocity");
                enemy.enemyRigidBody.AddForce(enemy.enemyRigidBody.velocity * 10f, ForceMode.Impulse);
            }
        }
        public void RotateEnemy(Enemy enemy)
        {
            Vector3 playerPosition = -playerGameObject.transform.position;
            Vector3 targetDirection = playerPosition + enemy.transform.position;

            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime);
        }
        
        
    }
}