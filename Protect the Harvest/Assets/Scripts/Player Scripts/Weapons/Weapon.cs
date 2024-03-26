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
        public virtual void HitController()
        {
            LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
            hitTestObject = GameObject.FindWithTag("Hit Cube");
            hitTestObject.transform.position = PlayerShootPoint.position+PlayerShootPoint.forward*Range;
            if (Physics.Raycast(PlayerShootPoint.position, PlayerShootPoint.forward,out var hit, Range, enemyLayerMask))
            {
               hit.transform.gameObject.GetComponent<IEnemy>().ReduceHealth(Damage);
            }
        }
        
        protected int GetWeaponDamage()
        {
            return Damage;
        }

        protected int GetWeaponRange()
        {
            return GunType.GetHashCode();
        }

        protected virtual void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<IEnemy>().ReduceHealth(Damage);
            }
        }
    }
}