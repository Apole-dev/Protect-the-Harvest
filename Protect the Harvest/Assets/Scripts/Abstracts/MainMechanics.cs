using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace Abstracts
{
    public abstract class MainMechanics : MonoBehaviour
    {
        [SerializeField] private Slider enemyHealthBar;
    
        //GAME MAIN MECHANICS
        public abstract void Attack();
        public abstract void Defence();
        public abstract void Heal();
    
        //GAME END MECHANICS
        public virtual void EnemyWin(){}
        public virtual void PlayerWin(){}
        
    
        /// <summary>
        /// Resets health of the enemy
        /// </summary>
        public virtual void ResetHealth()
        {
            enemyHealthBar.value = enemyHealthBar.maxValue;
        } 
    
    }
}