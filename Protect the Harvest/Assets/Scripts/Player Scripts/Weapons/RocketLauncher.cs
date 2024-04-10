using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Weapon;
using UnityEngine;

namespace Player_Scripts.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
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
        

        public override ObjectsScriptableData AssignNewWeapon()
        {
            int index = UnityEngine.Random.Range(0, rocketLaunchers.Count);
            Damage = rocketLaunchers[index].effectValue;
            Range = rocketLaunchers[index].range;
            return rocketLaunchers[index];
        }
        
    }
}
