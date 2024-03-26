using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player_Scripts.Weapons
{
    public class Shotgun : Weapon
    {
        [SerializeField] private List<ShotgunScriptableObject> shotguns;

        #region Abstract Properties
        public override int Damage { get; protected set; }
        public override int Range { get; protected set; }
        public override GunType GunType { get; protected set; }
        public override EffectType EffectType { get; protected set; }
        public override Transform PlayerShootPoint { get; set; }
        public override Transform EnemyShootPoint { get; set; }
        
        #endregion
        
        public float Radius { get; private  set; }

        private void Awake()
        {
            GunType = GunType.Shotgun;
            EffectType = EffectType.PlayerShotgunAttackEffect;
        }

        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = Random.Range(0, shotguns.Count);
            Damage = shotguns[index].effectValue;
            Range = shotguns[index].range;
            Radius = shotguns[index].hitRadius;
            return shotguns[index];
        }

        public override void HitController()
        {
            Vector3 hitPosition = PlayerShootPoint.position + PlayerShootPoint.forward * Range;
            hitTestObject.transform.position = hitPosition;
            var hitObjects = Physics.OverlapSphere(hitPosition, 1f, LayerMask.GetMask("Enemy")); 
            print(hitObjects.Length);
            if (hitObjects.Length > 4) return; 
          
            foreach (var coll in hitObjects)
            {
                print(coll.name);
                coll.transform.gameObject.GetComponent<IEnemy>().ReduceHealth(Damage);
            }
        }
    }
}