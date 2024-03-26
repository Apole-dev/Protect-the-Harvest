using System.Collections.Generic;
using Game_Scriptable_Objects;
using Game_Scriptable_Objects.Shield;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class Fence: MonoBehaviour
    {
        [Header("Fence Properties")]
        [SerializeField] private Slider fenceShieldSlider;
        [SerializeField] private List<ShieldScriptableObject> shieldObjects;
        
        public void ReduceShield(int damage)
        {
            fenceShieldSlider.gameObject.SetActive(true);
            fenceShieldSlider.value -= damage*Time.deltaTime;
            
            if (fenceShieldSlider.value <= 0)
            {
                gameObject.SetActive(false);
                UIManager.Instance.ShowShieldBrokeScreen(true);
                AudioManager.Instance.PlayShieldBrokeSound();
            }
        }
        
        public void IncreaseShield(int increaseAmount)
        {
            fenceShieldSlider.value += increaseAmount;
        }
        
        public ObjectsScriptableData GetRandomShield()
        {
            return shieldObjects[UnityEngine.Random.Range(0, shieldObjects.Count)];
        }
        
    }
}