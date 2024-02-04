using System;
using Singleton;

public sealed class CombatController : MonoSingleton<CombatController>
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