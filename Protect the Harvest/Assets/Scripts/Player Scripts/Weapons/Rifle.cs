using System;
using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Rifle : Weapon
    {
        [SerializeField] private List<RifleScriptableObject> rifleObjects;
        public override int Damage { get; protected set; } = 10;
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        private void Awake()
        {
            Range = 1;
            GunType = GunType.Rifle;
            EffectType = EffectType.PlayerRifleAttackEffect;
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            var index = UnityEngine.Random.Range(0,rifleObjects.Count);
            Damage = rifleObjects[index].effectValue;
            Range = rifleObjects[index].range;
            
            return rifleObjects[index];
        }
        

    }
}