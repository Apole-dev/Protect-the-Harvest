using System.Collections.Generic;
using Enums;
using Game_Scriptable_Objects.Health;
using Managers;
using UnityEngine;
using UnityEngine.UI;
namespace Player_Scripts
{
    public class PlayerHeal : MonoBehaviour
    {
        public float CurrentHealth { get; private set; } = 50;
        
        [SerializeField] private Slider playerHealthBar;
        [SerializeField] private List<HealthScriptableObjects> healthScriptableObjects;
        
        public void Heal(int healValue)
        {
            playerHealthBar.value +=healValue;
            CurrentHealth = playerHealthBar.value;
            EffectManager.Instance.PlayPlayerEffect(EffectType.PlayerHealEffect,transform);
            AudioManager.Instance.PlayHealthRechargeSound();
        }

        public void ReduceHealth(float damage)
        {
            playerHealthBar.value -= damage;
            CurrentHealth = (int)playerHealthBar.value;
        }


        public HealthScriptableObjects GetRandomHealthObject()
        {
            return healthScriptableObjects[UnityEngine.Random.Range(0, healthScriptableObjects.Count)];
        }
    }
}