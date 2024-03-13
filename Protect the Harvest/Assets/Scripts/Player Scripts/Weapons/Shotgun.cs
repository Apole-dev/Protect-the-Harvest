using System;
using Enums;
using Interfaces;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Shotgun : Weapon
    {
        public override int damage { get; set; }
        public override GunType gunType { get; protected set; }
        public override EffectType effectType { get; protected set; }
        public override Transform playerShootPoint { get; set; }
        public override Transform enemyShootPoint { get; set; }

        private void Awake()
        {
            gunType = GunType.Shotgun;
            effectType = EffectType.PlayerShotgunAttackEffect;
        }

        public override void Shoot(bool isHit)
        {
            base.Shoot(isHit);
            ShotgunAttack();
        }
        

        private void ShotgunAttack()
        {
            if (Physics.Raycast(playerShootPoint.position, playerShootPoint.forward,out var hit1,GetWeaponRange(),LayerMask.GetMask("Enemy")))
            {
                if (hit1.transform.CompareTag("Enemy"))
                {
                    hit1.transform.GetComponent<IEnemy>().ReduceHealth(damage);
                }
            }
            if (Physics.Raycast(playerShootPoint.position, playerShootPoint.forward + new Vector3(0,0,0.5f),out var hit2,GetWeaponRange(),LayerMask.GetMask("Enemy")))
            {
                if (hit2.transform.CompareTag("Enemy"))
                {
                    hit2.transform.GetComponent<IEnemy>().ReduceHealth(damage);
                }
            }
            if (Physics.Raycast(playerShootPoint.position, playerShootPoint.forward + new Vector3(0,0,-0.5f),out var hit3,GetWeaponRange(),LayerMask.GetMask("Enemy")))
            {
                if (hit3.transform.CompareTag("Enemy"))
                {
                    hit3.transform.GetComponent<IEnemy>().ReduceHealth(damage);
                }
            }
            if (Physics.Raycast(playerShootPoint.position, playerShootPoint.forward + new Vector3(0.5f,0,0),out var hit4,GetWeaponRange(),LayerMask.GetMask("Enemy")))
            {
                if (hit4.transform.CompareTag("Enemy"))
                {
                    hit4.transform.GetComponent<IEnemy>().ReduceHealth(damage);
                }
            }
        }
    }
}