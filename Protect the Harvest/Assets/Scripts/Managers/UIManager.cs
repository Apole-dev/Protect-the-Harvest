using Singleton;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        
        [SerializeField] private GameObject stageSelectionScreenObject;
        [SerializeField] private GameObject cardSelectionScreenObject;
        [SerializeField] private GameObject shieldBrokeScreenObject;
        [SerializeField] private GameObject gameOverScreenObject;
        [SerializeField] private GameObject victoryScreenObject;
        [SerializeField] private GameObject pauseMenuObject;
        [SerializeField] private GameObject loadingScreenObject;
        [SerializeField] private GameObject advertisementObject;
        [SerializeField] private GameObject playerInformationObject;
        [SerializeField] private GameObject joystickObject;
        [SerializeField] private GameObject abilityButtonsObject;
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
            joystickObject.SetActive(!isCardSelection);
            abilityButtonsObject.SetActive(!isCardSelection);
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

        public void ShowPlayerInformation(bool isPlayerInfo)
        {
            playerInformationObject.SetActive(isPlayerInfo);
        }

        public void ShowShieldBrokeScreen(bool isShieldBroke)
        {
            shieldBrokeScreenObject.SetActive(isShieldBroke);
        }
    }
}