using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using Interfaces;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class RocketLauncher : Weapon
    {
        [SerializeField] private List<RocketLauncherScriptableObject> rocketLaunchers;
        [SerializeField] private GameObject hitTrail;
        #region Abstracts
        public override int Damage { get; protected set; } = 5; //Normal value
        public override int Range { get; protected set; } = 3; //Normal value
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        #endregion
        
        private Rigidbody _rb;
        private float _bulletSpeed;
        private bool _isShot;
        private Vector3 _shootPosition;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            
            GunType = GunType.RocketLauncher;
            EffectType = EffectType.PlayerRocketLauncherAttackEffect;
            
            
        }

        private void FixedUpdate()
        {
            if (_isShot)
            {
                //bug fix if character not move object not moving
                _rb.position += _shootPosition * (_bulletSpeed * Time.fixedDeltaTime);
            }
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = UnityEngine.Random.Range(0, rocketLaunchers.Count);
            Damage = rocketLaunchers[index].effectValue;
            Range = rocketLaunchers[index].range;
            _bulletSpeed = rocketLaunchers[index].bulletSpeed;
            return rocketLaunchers[index];
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Shoot(bool isHit)
        {
            base.Shoot(isHit);
            gameObject.SetActive(true);
            _isShot = true;
            //StartCoroutine(ResetIsShoot());
            _shootPosition = PlayerShootPoint.forward;
        }
        
        private IEnumerator ResetIsShoot()
        {
            yield return new WaitForSeconds(3f);
            _isShot = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<IEnemy>().ReduceHealth(Damage);
                var  trail = Instantiate(hitTrail,other.transform.position,Quaternion.identity);
                Destroy(trail,0.5f);
                gameObject.SetActive(false);
            }
        }
        
    }
}
