using Interfaces;

public class Context
{ 
    private readonly CombatController _combatController;
    public ICombatState currentState { get; private set; }
    public Context(CombatController iCombatController)
    {
        _combatController = iCombatController;
    }

    public void ChangeState(ICombatState iState)
    {
        currentState = iState;
        iState.Handle(_combatController);
    }
}