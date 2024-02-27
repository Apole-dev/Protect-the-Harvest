using UnityEngine;

namespace Enemy_Scripts
{
    public class EnemyMovement : MonoBehaviour
    {
        public static float enemySpeed; 
        
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private float turnSpeed = 100f;
        private GameObject _enemyGameObject;
        private Rigidbody _enemyRb;
        
        private void Awake()
        {
            _enemyGameObject = transform.parent.gameObject;
            enemySpeed = EnemyRandomData.Instance.GetRandomSpeed();
            
            _enemyRb = _enemyGameObject.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_enemyRb.CompareTag("Spawn Manger Object"))
                return;
            
            
            EnemyMove();
            EnemyRotate();
        }

        private void EnemyMove()
        {
            var direction = (playerGameObject.transform.position - _enemyGameObject.transform.position).normalized*15f;
            _enemyRb.velocity = direction *(enemySpeed * Time.fixedDeltaTime);
        }

        private void EnemyRotate()
        {
            var playerPosition = -playerGameObject.transform.position;
            _enemyGameObject.transform.LookAt(playerPosition*turnSpeed);
        }
    }
}