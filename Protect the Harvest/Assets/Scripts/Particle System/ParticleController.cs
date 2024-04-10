using Game_Scriptable_Objects;
using Player_Scripts.Weapons;
using UnityEngine;

namespace Particle_System
{
    public class ParticleController : MonoBehaviour
    {
        public ObjectsScriptableData data;
        public Weapon currentWeaponType;
        public bool isShootActive;//Is the bullet active
        
        private GameObject _playerGameObjectShootPoint;
        private ParticleSystem _particleSystem;
        private Rigidbody _rigidBody;
        private ParticlePooling _particlePooling;

        
        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerGameObjectShootPoint = GameObject.FindWithTag("Shoot Point");
            _particlePooling = FindObjectOfType<ParticlePooling>();
        }

        private void Start()
        {
            transform.position = _playerGameObjectShootPoint.transform.position;
        }
        
        public void MoveParticle()
        {
            if (data == null)
            {
                return;
            }
            _rigidBody.velocity = (_playerGameObjectShootPoint.transform.forward) * (data.bulletSpeed * Time.deltaTime * 100);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                currentWeaponType.Hit(other.gameObject);
                _particlePooling.AddParticleToPool(gameObject);
            }
        }
    }
}
