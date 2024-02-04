using Singleton;

namespace Managers
{
    public class UIManager : MonoSingleton<UIManager>
    {
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