using System;
using Game_Scriptable_Objects;
using Player_Scripts.Weapons;
using UnityEngine;

namespace Particle_System
{
    [RequireComponent(typeof(Rigidbody)),
     RequireComponent(typeof(ParticleSystem)),
     RequireComponent(typeof(BoxCollider))]
    public class ParticleController : MonoBehaviour
    {
        public ObjectsScriptableData data;
        public Weapon currentWeaponType;
        
        private GameObject _playerGameObjectShootPoint;
        private ParticleSystem _particleSystem;
        private Rigidbody _rigidBody;
        private ParticlePooling _particlePooling;

        private float _time;

        
        private void Reset()
        {
            RigidBodyDefault();
            ColliderDefault();
            ParticleSystemDefault();
        }

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _rigidBody = GetComponent<Rigidbody>();
            _playerGameObjectShootPoint = GameObject.FindWithTag("Shoot Point");
            _particlePooling = FindObjectOfType<ParticlePooling>();
        }

        private void Update()
        {
            if (data == null) return;

            
            _time += Time.deltaTime;
            if (_time >= data.bulletLifeTime)
            {
                _particlePooling.AddParticleToPool(gameObject);
                _time = 0;
            }
             

            //Note: Distance Control
            
            // float distance = transform.position.z - _playerGameObjectShootPoint.transform.position.z;
            // if (distance > data.range)
            // {
            //     _particlePooling.AddParticleToPool(gameObject);
            // }
        }

        public void MoveParticle()
        {
            if (data != null)
            {
                print("Data not null");
                _rigidBody.velocity = (_playerGameObjectShootPoint.transform.forward) * (data.bulletSpeed);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                currentWeaponType.Hit(other.gameObject);
                _particlePooling.AddParticleToPool(gameObject);
            }
        }

        #region Defaults
        
        private void RigidBodyDefault()
        {
            Rigidbody rigidBody = GetComponent<Rigidbody>();
            rigidBody.useGravity = false;
            rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        private void ColliderDefault()
        {
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            
            LayerMask allLayerMask = ~0;
            LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            
            boxCollider.includeLayers =enemyLayer ;
            boxCollider.excludeLayers = allLayerMask & ~enemyLayer;; //except enemy            
        }

        private void ParticleSystemDefault()
        {
            ParticleSystem ps = GetComponent<ParticleSystem>();
            
            var main = ps.main;
            var shape = ps.shape;
            var emission = ps.emission;
            
            main.duration = 30f;
            main.startLifetime = 35f;
            main.playOnAwake = true;
            main.startDelay = 0;
            main.startSpeed = 0;
            main.maxParticles = 1;
            main.loop = false;
            main.simulationSpace = ParticleSystemSimulationSpace.Local;

            emission.enabled = true;
            emission.rateOverTime = 1f;
            ParticleSystem.Burst burst = new ParticleSystem.Burst(0.0f, 30, 1, 1, 1);
            emission.SetBursts(new[] { burst });
            shape.enabled = false;
        }

        #endregion

    }
}
