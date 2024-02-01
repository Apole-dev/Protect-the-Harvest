namespace Interfaces
{
    public interface IGameManager
    {
        void InitializeGame();
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void EndGame();
        void RestartGame();
    }
    
    
}