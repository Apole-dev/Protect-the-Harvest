using System;
using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class AssaultRifle : Weapon
    {
        [SerializeField] private List<AssaultRifleScriptableObject> assaultRifle;
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        private void Awake()
        {
            GunType = GunType.AssaultRifle;
            EffectType = EffectType.PlayerAssaultRifleAttackEffect;
        }
        
        public override AllScriptableData AssignNewWeapon()
        {
            var index = UnityEngine.Random.Range(0, assaultRifle.Count);
            Damage = assaultRifle[index].damage;
            Range = assaultRifle[index].range;
            
            return assaultRifle[index];
        }
        
    }
}