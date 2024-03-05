using System;
using Managers;
using UnityEngine;

namespace Player_Scripts
{
    public class Fence: MonoBehaviour
    {
        [Header("Fence Properties")]
        public FenceType fenceType;
        [SerializeField] private GameObject easyFence;
        [SerializeField] private GameObject mediumFence;
        [SerializeField] private GameObject hardFence;
        [SerializeField] private GameObject impossibleFence;
        [SerializeField] private GameObject brokenFence;
        public int currentShield { get; private set; }
        

        private void Awake()
        {
            currentShield = fenceType switch
            {
                FenceType.Easy => FenceType.Easy.GetHashCode(),
                FenceType.Medium => FenceType.Medium.GetHashCode(),
                FenceType.Hard => FenceType.Hard.GetHashCode(),
                FenceType.Impossible => FenceType.Impossible.GetHashCode(),
                _ => 10
            };
        }


        public void ReduceShield(int damage)
        {
            currentShield -= damage;
            if (currentShield <= 0)
            {
                gameObject.SetActive(false);
                UIManager.Instance.ShowShieldBrokeScreen(true);
                AudioManager.Instance.PlayShieldBrokeSound();
            }
        }

        public int GetCurrentDamage()
        {
            return currentShield;
        }
        
        public FenceType GetCurrentFenceType()
        {
            return fenceType;
        }

        public FenceType GetRandomFenceType()
        {
            int random = UnityEngine.Random.Range(0, 4);

            return random switch
            {
                0 => FenceType.Easy,
                1 => FenceType.Medium,
                2 => FenceType.Hard,
                3 => FenceType.Impossible,
                _ => FenceType.Easy
            };
        }

        public void ChangeFence(FenceType newFenceType)
        {
            fenceType = newFenceType;
            switch (newFenceType)
            {
                case FenceType.Easy:
                    //ActivateFence(FenceType.Easy);
                    break;
                case FenceType.Medium:
                    //ActivateFence(FenceType.Medium);
                    break;
                case FenceType.Hard:
                    //ActivateFence(FenceType.Hard);
                    break;
                case FenceType.Impossible:
                    //ActivateFence(FenceType.Impossible);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newFenceType), newFenceType, null);
            }
                
        }
        
        private void ActivateFence(FenceType activeFenceType)
        {
            switch (activeFenceType)
            {
                case FenceType.Easy:
                    easyFence.SetActive(true);
                    mediumFence.SetActive(false);
                    hardFence.SetActive(false);
                    impossibleFence.SetActive(false);
                    brokenFence.SetActive(false);
                    break;
                case FenceType.Medium:
                    mediumFence.SetActive(true);
                    easyFence.SetActive(false);
                    hardFence.SetActive(false);
                    impossibleFence.SetActive(false);
                    brokenFence.SetActive(false);
                    break;
                case FenceType.Hard:
                    hardFence.SetActive(true);
                    easyFence.SetActive(false);
                    mediumFence.SetActive(false);
                    impossibleFence.SetActive(false);
                    brokenFence.SetActive(false);
                    break;
                case FenceType.Impossible:
                    impossibleFence.SetActive(true);
                    easyFence.SetActive(false);
                    mediumFence.SetActive(false);
                    hardFence.SetActive(false);
                    brokenFence.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
    }

    public enum FenceType
    {
        Easy = 10,
        Medium = 30,
        Hard = 50,
        Impossible = 60
    }
}