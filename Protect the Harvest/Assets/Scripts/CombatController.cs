using System.Collections.Generic;
using UnityEngine;
using Abstracts;

public class CombatController : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;

    private List<MainMechanics> _observers;
    
    private void Awake()
    {
        _observers = new List<MainMechanics>();
        _player = GetComponent<Player>();
        _enemy = GetComponent<Enemy>();
    }

    #region Observer Section
        public void AddObserver(MainMechanics observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(MainMechanics observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            _observers.ForEach(p => p.PlayerWin());
            _observers.ForEach(e => e.EnemyWin());
        }
    #endregion
    
    
}