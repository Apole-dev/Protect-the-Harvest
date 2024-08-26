namespace Enemy_Scripts.Our_Enemy.Interface
{
    public interface IOurEnemyHealth
    {
        public void UpdateHealth(float currentHealth, float maxHealth);
        public void ResetHealth(float health);
        public void Death();
    }
}