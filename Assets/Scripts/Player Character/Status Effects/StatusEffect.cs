using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public string Name;
    protected bool canLeave = false;
    protected bool isExiting = false;
    public bool IsExiting => isExiting;
    public abstract bool CanAccess(StatusEffects mech);
    public virtual void Start(StatusEffects mech)
    {
        isExiting = false;
        mech.CurrentState = this;
        mech.PC.TestUi.UpdateMovementStateText(Name);
    }
    public abstract void Update();
    public virtual bool CanLeave() => canLeave;
    public virtual void Leave() { canLeave = false; isExiting = true; }

}
