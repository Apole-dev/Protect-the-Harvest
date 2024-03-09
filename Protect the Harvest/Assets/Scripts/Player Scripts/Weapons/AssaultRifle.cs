using System;
using Enums;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class AssaultRifle : Weapon
    {
        public override int damage { get; set; }
        public override GunType gunType { get; protected set; }
        public override EffectType effectType { get; protected set; }
        public override Transform playerShootPoint { get; set; }
        public override Transform enemyShootPoint { get; set; }

        private void Awake()
        {
            gunType = GunType.AssaultRifle;
            effectType = EffectType.PlayerAssaultRifleAttackEffect;
            
        }
    }
}