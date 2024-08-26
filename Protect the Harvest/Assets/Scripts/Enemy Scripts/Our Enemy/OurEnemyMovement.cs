using UnityEngine;

namespace Enemy_Scripts.Our_Enemy
{
    public class OurEnemyMovement : MonoBehaviour
    {
        public void OurEnemyMove( GameObject ourEnemy ,GameObject target,Rigidbody rb ,float speed)
        {
            var direction = target.transform.position - ourEnemy.transform.position;
            rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;
        }

        public void OurEnemyStop(Rigidbody rb)
        {
            rb.velocity = Vector3.zero;
        }

        public void OurEnemyRotate(GameObject ourEnemy, GameObject target, float turnSpeed)
        {
            var direction = target.transform.position - ourEnemy.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            ourEnemy.transform.rotation = Quaternion.RotateTowards(ourEnemy.transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime);
        }
    }
}