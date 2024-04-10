using System;
using Enums;
using Game_Scriptable_Objects;
using Particle_System;
using Player_Scripts.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player_Scripts
{
    public class PlayerAttack : MonoBehaviour 
    {
        public ObjectsScriptableData dataOfCurrentWeapon;
        public Weapon currentWeaponType;
        
        private float _time;
        private ObjectsScriptableData _tempObjectsScriptableData;

        private void Update()
        {

            if (ButtonPressController.isPressContinue)
            { 
                _time += Time.deltaTime;
                if (_time > 1)
                {
                    Attack();
                    _time = 0;
                }
            }
        }
        
        private void Attack()
        {
           print("Attack");
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
