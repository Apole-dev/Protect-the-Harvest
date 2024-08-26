namespace Enemy_Scripts.Our_Enemy.Interface
{
    public interface IOurEnemyHit
    {
        public void TakeDamage(float damage);
        public void PushBack(float pushAmount);
    }
}