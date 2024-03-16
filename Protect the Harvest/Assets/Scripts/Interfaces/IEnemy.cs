using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface IEnemy
    {
        public int Damage { get; set; }
        public int Health { get; set; }

        public int Speed { get; set; }
        
        public int FireRate { get; set; }
        
        public void ReduceHealth(float playerDamage);

        public void PushBack(float pushAmount);
        public void ChangeColor();
        public void HitText(float duration,float playerDamage , Color color);

       

    }
}