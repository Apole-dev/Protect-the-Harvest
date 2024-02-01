using Interfaces;
using Singleton;

namespace Managers
{
    public class GameManager : MonoSingleton<GameManager> , IGameManager
    {
        public void InitializeGame()
        {
            throw new System.NotImplementedException();
        }

        public void StartGame()
        {
            throw new System.NotImplementedException();
        }

        public void PauseGame()
        {
            throw new System.NotImplementedException();
        }

        public void ResumeGame()
        {
            throw new System.NotImplementedException();
        }

        public void EndGame()
        {
            throw new System.NotImplementedException();
        }

        public void RestartGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
