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

        public RifleScriptableObject rifleScriptableObject;

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
            
            rifleScriptableObject = rifleObjects[index];
            return rifleScriptableObject;
        }

        public override GameObject Shoot()
        {
           var bullet =  InstantiateBullet(rifleScriptableObject.bulletPrefab);
           return bullet;
        }

        public override void Hit(GameObject hitObject)
        {
            if (hitObject == null) return;

            var colliders = Physics.CapsuleCastAll(hitObject.transform.position, hitObject.transform.position.AddZWidth(0.3f), 0.1f, hitObject.transform.forward, 0.5f, LayerMask.GetMask("Enemy"));
            if (colliders.Length == 0) return;
            print($"<color=#FFB1B1>Hit Count: </color>"+colliders.Length);
            
            foreach (var collider in colliders)
            {
                Func<IEnemy> func = collider.transform.GetComponent<IEnemy>;
                func().ReduceHealth(rifleScriptableObject.effectValue);
                func().ChangeColor();
                func().HitText(1f,rifleScriptableObject.effectValue,Color.blue);
            }
            
        }
    }
}