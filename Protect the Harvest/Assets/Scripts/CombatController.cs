using System;
using Enums;
using Managers;
using Singleton;
using UnityEngine;



public sealed class CombatController : MonoSingleton<CombatController>
{
    public event EventHandler<CombatEventArgs> CombatEvent;
    
    private Context _context;
    

    private void Awake()
    {
        _context = new Context(this);
    }

    private void Update()
    {
        //Test InstantiateEffect();
        if (Input.touchCount > 0)
        {
            if (TouchPhase.Began == Input.GetTouch(0).phase)
            {
              
            }
        }
    }

    #region Observer

    

    private void OnCombatEvent(CombatEventArgs e)
    {
        CombatEvent?.Invoke(this, e);
    }

    public void PlayerWinEvent()
    {
        OnCombatEvent(new CombatEventArgs("Player"));
        
    }
    
    public void EnemyWinEvent()
    {
        OnCombatEvent(new CombatEventArgs("Enemy"));
    }
    #endregion 

    
    
}