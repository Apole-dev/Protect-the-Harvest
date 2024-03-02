using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy_Scripts
{ 
    public class EnemyHealth : MonoBehaviour
    {
        public float currentHealth;

        public void AssignHealth(Slider healthBar ,float maxHealth)
        {
            healthBar.maxValue = maxHealth;
            
            //starts at max health
            healthBar.value = maxHealth;
        }
        public bool ReduceHealth(float playerDamage,Slider healthBar)
        {
            healthBar.value -= playerDamage;
            currentHealth = healthBar.value;
            return healthBar.value == 0;
        }

        public void IncreaseHealth(float increaseAmount)
        {
            
        }
    }
}