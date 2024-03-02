namespace Interfaces
{
    public interface IEnemy
    {
        public void ReduceHealth(float playerDamage);
        
        public void MoveToThePool();
        public void ReturnFromPool();
    }
}