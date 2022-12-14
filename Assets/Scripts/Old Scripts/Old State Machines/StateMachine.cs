using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    public PC_Main PC;
    public State1 CurrentState = null;
    public Dictionary<string, State1> stateList = new Dictionary<string, State1>();

    public abstract void Update();

    public bool ChangeState(State1 newState)
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
