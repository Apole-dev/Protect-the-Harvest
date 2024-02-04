using System;

public class CombatEventArgs : EventArgs
{
    public string winner { get; private set; }

    public CombatEventArgs(string winner)
    {
        this.winner = winner;
    }
    
}
