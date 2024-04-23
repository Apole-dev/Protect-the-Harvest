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

        private RocketLauncherScriptableObject selectedWeapon;
    
        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = Random.Range(0, rocketLaunchers.Count);
            Damage = rocketLaunchers[index].effectValue;
            Range = rocketLaunchers[index].range;
            selectedWeapon = rocketLaunchers[index];

            return selectedWeapon;
        }

        public override GameObject Shoot()
        {
            var bullet = InstantiateBullet(selectedWeapon.bulletPrefab);
            return bullet;
        }
        
        
        //BUG: RocketLauncher push enemies to much that cause give a upward force to the enemies
        public override void Hit(GameObject hitObject)
        {
            if (hitObject == null) return;

            var hitEnemies = Physics.OverlapSphere(hitObject.transform.position, 10f, LayerMask.GetMask("Enemy"));
            print(hitEnemies.Length);
            foreach (var enemy in hitEnemies)
            {
                enemy.GetComponent<IEnemy>().ReduceHealth(Damage);
                enemy.GetComponent<Rigidbody>().AddExplosionForce(selectedWeapon.pushAmount,hitObject.transform.position,10f,0,ForceMode.VelocityChange);
            }
        }
    }
}
