using Singleton;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public bool stageSelectionScreen = false;
        public bool cardSelectionScreen = false;
        public bool combatScreen = false;
        public bool gameOverScreen = false;
        public bool victoryScreen = false;
        public bool pauseMenu = false;
        public bool loadingScreen = false;
        public bool advertisement = false;
        
        [SerializeField] private GameObject stageSelectionScreenObject;
        [SerializeField] private GameObject cardSelectionScreenObject;
        [SerializeField] private GameObject combatScreenObject;
        [SerializeField] private GameObject gameOverScreenObject;
        [SerializeField] private GameObject victoryScreenObject;
        [SerializeField] private GameObject pauseMenuObject;
        [SerializeField] private GameObject loadingScreenObject;
        [SerializeField] private GameObject advertisementObject;

        public void ShowMessage(string message)
        {
            
        }

        public void UpdateScore(int score)
        {
           
        }

        public void ShowHealthBar(int currentHealth, int maxHealth)
        {
           
        }

        public void ShowGameOverScreen()
        {
           
        }

        public void ShowVictoryScreen(bool isWin)
        {
            stageSelectionScreenObject.SetActive(isWin);
        }
        
        public void ShowCardSelectionScreen(bool isCardSelection)
        {
            cardSelectionScreenObject.SetActive(isCardSelection);
        }

        public void ShowPauseMenu()
        {
            
        }

        public void ShowLoadingScreen()
        {
           
        }

        public void ShowAdvertisement()
        {
            
        }

        
       
    }
}