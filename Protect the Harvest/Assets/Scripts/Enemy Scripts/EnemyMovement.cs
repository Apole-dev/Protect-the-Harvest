using Singleton;
using UnityEngine;

namespace Enemy_Scripts
{
    public sealed class EnemyMovement : MonoBehaviour
    {
        
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private float turnSpeed = 500f;

        public void MoveEnemy(Enemy enemy)
        {
            Vector3 direction = (playerGameObject.transform.position - enemy.transform.position).normalized;
            enemy.EnemyRigidBody.velocity = direction * (Time.fixedDeltaTime * enemy.Speed * 10f);

            if (Mathf.Abs(enemy.EnemyRigidBody.velocity.z) <= 0.15f)
            {
                print("added force due to zero velocity");
                enemy.EnemyRigidBody.AddForce(enemy.EnemyRigidBody.velocity * 10f, ForceMode.Impulse);
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