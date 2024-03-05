using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class PlayerHeal : MonoBehaviour
    {
        public int currentHealth{ get; private set; } = 50;
        [SerializeField] private Slider playerHealthBar;
        
        public void Heal(int healValue)
        {
            playerHealthBar.value += healValue;
            playerHealthBar.value = currentHealth;
        }

        public void ReduceHealth(float damage)
        {
            playerHealthBar.value -= damage;
            currentHealth = (int)playerHealthBar.value;
        }
    }
}