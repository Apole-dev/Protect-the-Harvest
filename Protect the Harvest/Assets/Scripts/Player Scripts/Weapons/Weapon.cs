using System;
using Enums;
using Game_Scriptable_Objects;
using Interfaces;
using Managers;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    [Serializable]
    public abstract class Weapon : MonoBehaviour
    {
        //Refactor: Damage and Range should removed.
        public abstract int Damage { get; protected set; }
        public abstract int Range { get; protected set; }
        public abstract GunType GunType { get; protected set; } 
        public abstract EffectType EffectType { get; protected set; }
        
        public abstract Transform PlayerShootPoint { get; set; }
        public abstract Transform EnemyShootPoint { get; set; }

        public GameObject hitTestObject;
        
        public abstract ObjectsScriptableData AssignNewWeapon();
        

        public virtual void Shoot(bool isHit)
        {
            EffectManager.Instance.PlayPlayerEffect(EffectType,PlayerShootPoint);
            AudioManager.Instance.PlayGunSound(GunType);

            if (isHit)
            {
                EffectManager.Instance.PlayEnemyHitEffect(EnemyShootPoint);
            }
            HitController();
        }

        public virtual GameObject Shoot()
        {
            // EffectManager.Instance.PlayPlayerEffect(EffectType,PlayerShootPoint);
            // AudioManager.Instance.PlayGunSound(GunType);
            HitController();
            return null;
        }
        public virtual void HitController()
        {
            hitTestObject = GameObject.FindWithTag("Hit Cube");
            PlayerShootPoint = GameObject.FindWithTag("Shoot Point").transform;
            hitTestObject.transform.position = PlayerShootPoint.position+PlayerShootPoint.forward*Range;
        }

        public virtual void Hit(GameObject hitObject)
        {
            print("hit");
        }
        
        protected int GetWeaponDamage()
        {
            return Damage;
        }

        protected int GetWeaponRange()
        {
            return GunType.GetHashCode();
        }
        
    }
}