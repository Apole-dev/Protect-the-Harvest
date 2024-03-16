using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Rifle :Weapon
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
            GunType = GunType.Rifle;
            EffectType = EffectType.PlayerRifleAttackEffect;
        }

        public override AllScriptableData AssignNewWeapon()
        {
            var index = UnityEngine.Random.Range(0,rifleObjects.Count);
            Damage = rifleObjects[index].damage;
            Range = rifleObjects[index].range;
            
            return rifleObjects[index];
        }
    }
}