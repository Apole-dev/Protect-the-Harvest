using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using Interfaces;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class Pistol : Weapon
    {
        [SerializeField] private List<PistolScriptableObject> pistolObjects;
        
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }


        public PistolScriptableObject selectedWeapon;
        private void Awake()
        {
            GunType = GunType.Pistol;
            EffectType = EffectType.PlayerPistolAttackEffect;
        }
        
        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = Random.Range(0, pistolObjects.Count);
            Damage = pistolObjects[index].effectValue;
            Range = pistolObjects[index].range;
            selectedWeapon = pistolObjects[index];
            WriteDataOfWeapon();
            return selectedWeapon;
        }

        public override GameObject Shoot()
        {
            var bullet = InstantiateBullet(selectedWeapon.bulletPrefab);
            return bullet;
        }

        public override void Hit(GameObject hitObject)
        {
            print("hit pistol");
            IEnemy component = hitObject.GetComponent<IEnemy>();
            
            component.ReduceHealth(10);
            component.PushBack(80f);
            component.ChangeColor(); 
            component.HitText(1f,selectedWeapon.effectValue,Color.red);
        }
    }
}