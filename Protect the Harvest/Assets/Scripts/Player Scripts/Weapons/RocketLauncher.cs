using Enums;
using Interfaces;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    public class RocketLauncher : Weapon
    {
        public override int damage { get; set; } = 5; //Normal value
        public override GunType gunType { get; protected set; }
        public override EffectType effectType { get; protected set; }
        public override Transform playerShootPoint { get; set; }
        public override Transform enemyShootPoint { get; set; }

        private void Awake()
        {
            gunType = GunType.RocketLauncher;
            effectType = EffectType.PlayerRocketLauncherAttackEffect;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<IEnemy>().ReduceHealth(damage);
            }
        }
    }
}
