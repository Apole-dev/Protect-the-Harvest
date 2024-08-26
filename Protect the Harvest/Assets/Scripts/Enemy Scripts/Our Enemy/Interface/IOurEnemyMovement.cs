using UnityEngine;

namespace Enemy_Scripts.Our_Enemy.Interface
{
    public interface IOurEnemyMovement
    {
        public void Move();
        public void Rotate();
        public void Stop();
    }
}