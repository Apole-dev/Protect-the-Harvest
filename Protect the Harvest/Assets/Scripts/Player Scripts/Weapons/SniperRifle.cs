using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class SniperRifle : Weapon
    {
        [SerializeField] private List<SniperRifleScriptableObject> sniperRifles;

        #region Abstracts
        
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }
        
        #endregion

        private SniperRifleScriptableObject _selectedWeapon;

        private void Awake()
        {
            GunType = GunType.SniperRifle;
            EffectType = EffectType.PlayerSniperRifleAttackEffect;
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = UnityEngine.Random.Range(0, sniperRifles.Count);
            Damage = sniperRifles[index].effectValue;
            Range = sniperRifles[index].range;
            
            _selectedWeapon = sniperRifles[index];
            return _selectedWeapon;
        }

        public override GameObject Shoot()
        {
            var bullet = InstantiateBullet(_selectedWeapon.bulletPrefab);
            return bullet;
        }
        
    }
}