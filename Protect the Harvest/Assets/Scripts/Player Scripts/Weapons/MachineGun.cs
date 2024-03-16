using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class MachineGun : Weapon
    {
        [SerializeField] private List<MachineGunScriptableObject> machineGuns;
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        private void Awake()
        {
            GunType = GunType.MachineGun;
            EffectType = EffectType.PlayerMachineGunAttackEffect;
        }

        public override AllScriptableData AssignNewWeapon()
        {
            var index = UnityEngine.Random.Range(0, machineGuns.Count);
            Damage = machineGuns[index].damage;
            Range = machineGuns[index].range;
            
            return machineGuns[index];
        }
    }
}