using System;
using UnityEngine;

public sealed class CombatController : MonoBehaviour
{
    public event EventHandler<CombatEventArgs> CombatEvent;

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
}