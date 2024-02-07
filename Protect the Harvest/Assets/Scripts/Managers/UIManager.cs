using Singleton;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public bool cardSelectionScreen = false;
        public bool combatScreen = false;
        public bool gameOverScreen = false;
        public bool victoryScreen = false;
        public bool pauseMenu = false;
        public bool loadingScreen = false;
        public bool advertisement = false;
        
        private void Awake()
        {
            CombatController.Instance.CombatEvent += HandleCombatEvent;
        }


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

        public void ShowVictoryScreen()
        {
            
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


        private void HandleCombatEvent(object sender, CombatEventArgs e)
        {
            switch (e.winner)
            {
                case "Player":
                    //TODO: PLAYER WIN
                    break;
                case "Enemy":
                    //TODO: ENEMY WIN
                    break;
            }
        }
    }
}