using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class PlayerHeal : MonoBehaviour
    {
        public static float currentHeal;
        private float healValue;
        private Inventory _inventory;
        
        [SerializeField] private Slider playerHealthBar;

        private void Awake()
        {
            _inventory = FindObjectOfType<Inventory>();
        }

        public void Heal()
        {
            healValue += _inventory.chosenHealth;
            playerHealthBar.value = currentHeal;
        }

        public void ReduceHealth(float damage)
        {
            playerHealthBar.value -= damage;
            currentHeal = playerHealthBar.value;
        }
    }
}