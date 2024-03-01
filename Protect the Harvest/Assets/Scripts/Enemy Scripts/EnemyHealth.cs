using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{ 
    public class EnemyHealth : MonoBehaviour 
    {

        public bool ReduceHealth(float playerDamage,Slider healthBar)
        {
            healthBar.value -= playerDamage;
            return healthBar.value == 0;
        }

        public void IncreaseHealth(float increaseAmount)
        {
            
        }
    }
}