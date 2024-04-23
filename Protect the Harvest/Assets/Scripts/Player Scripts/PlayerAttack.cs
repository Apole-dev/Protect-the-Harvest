using Game_Scriptable_Objects;
using Particle_System;
using Player_Scripts.Weapons;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player_Scripts
{
    public class PlayerAttack : MonoBehaviour 
    {
        [Header("Third Party")]
        public ObjectsScriptableData dataOfCurrentWeapon;
        public Weapon currentWeaponType;

        
        [Header("In Game Objects")]
        [SerializeField] private ParticlePooling particlePooling; 
        [SerializeField] private Transform shootPoint;
        
        private float _time;
        private ObjectsScriptableData _tempObjectsScriptableData;

        private void Update()
        {
            if (dataOfCurrentWeapon == null)
            {
                return;
            }
            if (ButtonPressController.isPressContinue)
            {
                FireWithRate();
            }
        }

        private void FireWithRate()
        {
            _time += Time.deltaTime;
            if (_time > 1/dataOfCurrentWeapon.fireRate)
            {
                
               if (particlePooling.GetParticleCount() < 1)
               {
                   Attack();
               }
               else
               {
                   GameObject bulletParticle = particlePooling.GetParticleFromPool();
                   bulletParticle.SetActive(true);
                   bulletParticle.transform.position = shootPoint.position;
                   bulletParticle.GetComponent<Rigidbody>().velocity = Vector3.zero;
                   ParticleController controller = bulletParticle.GetComponent<ParticleController>(); 
                   controller.MoveParticle();
               }
               
               _time = 0;
            }
        }

        private void Attack()
        {
            InstantiateBullet();
        }

        private void InstantiateBullet()
        {
            var bullet = currentWeaponType.Shoot();
            var controller = bullet.GetComponent<ParticleController>();
        
            controller.data = dataOfCurrentWeapon;
            controller.currentWeaponType = currentWeaponType;
            controller.MoveParticle();
        }
        
        public void ChangeWeapon(Weapon weaponType,ObjectsScriptableData objectsScriptableData)
        {
            dataOfCurrentWeapon = objectsScriptableData;
            currentWeaponType = weaponType;
            _tempObjectsScriptableData = dataOfCurrentWeapon;
        }
    }
}
