using UnityEngine;
using Slider = UnityEngine.UI.Slider;

namespace Abstracts
{
    public abstract class MainMechanics : MonoBehaviour
    {
        public abstract float currentDamage { get; set; }
        public abstract float currentHealth { get; set; }
        public abstract float currentDefence { get; set; }
        
        [SerializeField] protected Slider enemyHealthBar;
        [SerializeField] protected GameObject separator;
        [SerializeField] protected GameObject testObject;
        [SerializeField] protected float areaWidth;
        [SerializeField] protected float areaHeight;
    
        //GAME MAIN MECHANICS
        public abstract void Attack();
        public abstract void Defence();
        public abstract void Heal();
        
    
        /// <summary>
        /// Resets health of the enemy
        /// </summary>
        public virtual void ResetHealth()
        {
            enemyHealthBar.value = enemyHealthBar.maxValue;
        } 

     
        public virtual void InstantiateEffect()
        {
            separator.SetActive(true);
            var transformPosition = separator.transform.position;

            var x = Random.Range(transformPosition.x+areaWidth, transformPosition.x-areaWidth);
            var z = Random.Range(transformPosition.z+areaHeight, transformPosition.z-areaHeight);
        
            var instantiatePosition = new Vector3(x ,transformPosition.y, z);
       
            testObject.transform.position = instantiatePosition;
        }
        
    }
}