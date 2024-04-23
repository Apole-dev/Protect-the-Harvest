using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
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

        private MachineGunScriptableObject _selectedWeapon;
        

        private void Awake()
        {
            GunType = GunType.MachineGun;
            EffectType = EffectType.PlayerMachineGunAttackEffect;
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            var index = UnityEngine.Random.Range(0, machineGuns.Count);
            Damage = machineGuns[index].effectValue;
            Range = machineGuns[index].range;
            
            _selectedWeapon = machineGuns[index];
            return _selectedWeapon;
        }

        public override GameObject Shoot()
        {
            print("Machine Gun Shoot");
            var bullet = InstantiateBullet(_selectedWeapon.bulletPrefab);
            return bullet;
        }
    }
}