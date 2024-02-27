using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Slider healthBar;
        
        [Header("Current Situation")]
        [SerializeField] private float currentHealth;
        [SerializeField] private float currentDamage;
        [SerializeField] private float currentDefence;


        private PlayerAttack _playerAttack;




        private void Awake()
        {
            _playerAttack = FindObjectOfType<PlayerAttack>();
        }


        private void Update()
        {
            _playerAttack.DrawWeaponShootLine();
        }
        
        public void ReduceHealth(float damage)
        {
            currentHealth -= damage;
            healthBar.value = currentHealth;
        }
       
    }
    
    

}