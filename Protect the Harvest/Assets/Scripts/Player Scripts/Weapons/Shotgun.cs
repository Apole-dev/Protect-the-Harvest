using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private List<ShotgunScriptableObject> shotguns;
        
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        private void Awake()
        {
            GunType = GunType.Shotgun;
            EffectType = EffectType.PlayerShotgunAttackEffect;
        }

        public override AllScriptableData AssignNewWeapon()
        {
            int index = Random.Range(0, shotguns.Count);
            Damage = shotguns[index].damage;
            Range = shotguns[index].range;
            
            return shotguns[index];
        }
    }
}