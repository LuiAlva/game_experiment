using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomExtensions;

public abstract class State1 
{
    public string Name;
    protected bool canLeave = false;
    protected bool isExiting = false;
    public bool IsExiting => isExiting;
    public abstract bool CanAccess(StateMachine mech);
    public virtual void Start(StateMachine mech)
    {
        isExiting = false;
        mech.CurrentState = this;
        mech.PC.TestUi.MovementStateText.LabeledText("Movement", Name);
        //mech.PC.TestUi.UpdateMovementStateText(Name);
    }
    public virtual bool CanLeave() => canLeave;
    public virtual void Leave() { canLeave = false; isExiting = true; }
}
 