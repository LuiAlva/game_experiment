using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ChangeState() is bool so it can tell InputManager that it can happen. if don't need, change back to void.
 * Input manager will trigger StateChange().
 * PC_State.Name can change according to what the current state is doing with the different inputs. If swimming, then Movement state will change name
 * to Swimming. if dashing while in the water, then  the dashing state will change name to SwimDash.
 * If shooting while moving then moving will be named Move_Shoot.   --- ^^^DON'T DO THIS^^^
 * I think we may need state changes for Movement separate from Actions instead of name changes. Makes more sense.
 * Movement State Manager and Action State Manager.
 * MOVE IsSwimming to somewhere Else!!!
 */

public abstract class StateMachine
{
    public PC_Main PC;
    public State CurrentState = null;
    public bool IsSwimming;
    protected Dictionary<string, State> stateList = null;


    protected abstract void AddStates();

    public abstract void Update();

    public bool ChangeState(State newState)
    {
        if (newState != CurrentState && CurrentState.CanLeave())
        {
            if (newState.CanAccess(this)) { CurrentState.Leave(); newState.Start(this); return true; }
        }
        return false;
    }
}
