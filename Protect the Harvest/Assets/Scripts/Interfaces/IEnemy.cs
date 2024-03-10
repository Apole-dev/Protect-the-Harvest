using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface IEnemy
    {
        public int damage { get; set; }
        public int health { get; set; }

        public int speed { get; set; }
        
        public int fireRate { get; set; }
        
        
        public void ReduceHealth(float playerDamage);

        public void PushBack(float pushAmount);
        public void ChangeColor();
        public void HitText(float duration,float playerDamage , Color color);
        public void MoveToThePool();
        public void ReturnFromPool();
        
    }
}