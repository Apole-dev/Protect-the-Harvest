using System;
using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using Interfaces;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class RocketLauncher : Weapon
    {
        [SerializeField] private List<RocketLauncherScriptableObject> rocketLaunchers;
        #region Abstracts
        public override int Damage { get; protected set; } = 5; //Normal value
        public override int Range { get; protected set; } = 3; //Normal value
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }

        #endregion
        

        private void Awake()
        {
            GunType = GunType.RocketLauncher;
            EffectType = EffectType.PlayerRocketLauncherAttackEffect;
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = UnityEngine.Random.Range(0, rocketLaunchers.Count);
            Damage = rocketLaunchers[index].effectValue;
            Range = rocketLaunchers[index].range;
            
            return rocketLaunchers[index];
        }

        public override void HitController()
        {
            Vector3 hitPosition = PlayerShootPoint.position + PlayerShootPoint.forward * Range;
            hitTestObject.transform.position = hitPosition;
            var hitObjects = Physics.OverlapSphere(hitPosition, 1f, LayerMask.GetMask("Enemy")); 
            print(hitObjects.Length);
            if (hitObjects.Length > 6) return; 
          
            foreach (var coll in hitObjects)
            {
                print(coll.name);
                coll.transform.gameObject.GetComponent<IEnemy>().ReduceHealth(Damage);
            }
        }

        protected override void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                var hitObjects = Physics.OverlapSphere(other.transform.position, 1f, LayerMask.GetMask("Enemy")); 
                print(hitObjects.Length);
                if (hitObjects.Length > 6) return; 
          
                foreach (var coll in hitObjects)
                {
                    print(coll.name);
                    coll.transform.gameObject.GetComponent<IEnemy>().ReduceHealth(Damage);
                }  
            }
        }
    }
}
