using System;
using Enums;
using Game_Scriptable_Objects;
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
        
        public virtual void Shoot(bool isHit)
        {
            print(GunType);
            EffectManager.Instance.PlayPlayerEffect(EffectType,PlayerShootPoint);
            AudioManager.Instance.PlayGunSound(GunType);

            if (isHit)
            {
                EffectManager.Instance.PlayEnemyHitEffect(EnemyShootPoint);
            }
        }

        public virtual AllScriptableData AssignNewWeapon()
        {
            return null;
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