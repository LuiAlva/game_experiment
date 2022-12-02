using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public PC_Main PC;
    public State CurrentState = null;
    public Dictionary<string, State> stateList = new Dictionary<string, State>();

    public abstract void Update();

    public bool ChangeState(State newState)
    {
        if (newState != CurrentState && CurrentState.CanLeave())
        {
            if (newState.CanAccess(this))
            {
                CurrentState.Leave();
                CurrentState = newState;
                CurrentState.Start(this);
                return true; }
        }
        return false;
    }

    protected abstract void addState();
}
