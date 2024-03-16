using System;
using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
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

        public override AllScriptableData AssignNewWeapon()
        {
            int index = UnityEngine.Random.Range(0, rocketLaunchers.Count);
            Damage = rocketLaunchers[index].damage;
            Range = rocketLaunchers[index].range;
            
            return rocketLaunchers[index];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
                other.GetComponent<IEnemy>().ReduceHealth(Damage);
        }
        public Rarity GetWeightRarity()
        {
            int weightRarity = RandomProbability.WeightedProbability(new[] { 50, 10, 5 }, new[] { 1, 2, 3 });
            foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
            {
                if ((int)rarity == weightRarity)
                {
                    return rarity;
                }
            }
            return Rarity.Common;
        }
    }
}
