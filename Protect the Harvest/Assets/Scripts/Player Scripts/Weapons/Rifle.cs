using System;
using Enums;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Rifle :Weapon
    {
        public override int damage { get; set; } = 10;
        public override GunType gunType { get; protected set; }
        public override EffectType effectType { get; protected set; }
        public override Transform playerShootPoint { get; set; }
        public override Transform enemyShootPoint { get; set; }

        private void Awake()
        {
            gunType = GunType.Rifle;
            effectType = EffectType.PlayerRifleAttackEffect;
        }
    }
}