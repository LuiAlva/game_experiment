using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffects
{
    public PC_Main PC;
    public StatusEffect CurrentState = null;
    public bool IsSwimming;
    protected Dictionary<string, State1> statelist0 = null;


    protected abstract void AddStates();

    public virtual void Update()
    {
        CurrentState?.Update();
    }

    public bool ChangeState(StatusEffect newState)
    {
        if (newState != CurrentState && CurrentState.CanLeave())
        {
            if (newState.CanAccess(this)) { CurrentState.Leave(); newState.Start(this); return true; }
        }
        return false;
    }
}
