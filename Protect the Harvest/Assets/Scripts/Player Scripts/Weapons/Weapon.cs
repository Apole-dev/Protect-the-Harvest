using Enums;
using Managers;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract int damage { get; set; }
        public abstract GunType gunType { get; protected set; } 
        public abstract EffectType effectType { get;protected set; }
        
        public abstract Transform playerShootPoint { get; set; }
        public abstract Transform enemyShootPoint { get; set; }
        
        public virtual void Shoot(bool isHit)
        {
            print(gunType);
            EffectManager.Instance.PlayPlayerEffect(effectType,playerShootPoint);
            AudioManager.Instance.PlayGunSound(gunType);

            if (isHit)
            {
                print("ishit true it needs to bewro");
                EffectManager.Instance.PlayEnemyHitEffect(enemyShootPoint);
            }
        }

        public int GetWeaponDamage()
        {
            return damage;
        }

        public int GetWeaponRange()
        {
            return gunType.GetHashCode();
        }
    }
}