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
        public ShotgunScriptableObject selectedWeapon;

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
            selectedWeapon =  shotguns[index];
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
            var position = hitObject.transform.position;
            var colliders = Physics.OverlapSphere(hitObject.transform.position, Radius, LayerMask.GetMask("Enemy"));
            if (colliders == null) return;

            foreach (var collider in colliders)
            {
                var component = collider.gameObject.GetComponent<IEnemy>();
                
                component.ReduceHealth(selectedWeapon.effectValue);
                component.ChangeColor();
                component.HitText(1f,selectedWeapon.effectValue,Color.blue);
            }

        }
    }
}