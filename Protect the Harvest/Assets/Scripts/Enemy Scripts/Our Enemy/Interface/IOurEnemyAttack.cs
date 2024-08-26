using Player_Scripts;

namespace Enemy_Scripts.Our_Enemy.Interface
{
    public interface IOurEnemyAttack
    {
        public void Attack();
        public void StopAttack();
        public void ResetAttack();
    }
}