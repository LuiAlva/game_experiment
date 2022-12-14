using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MovementSpeedLeisurely : State1
{
    public State_MovementSpeedLeisurely() { Name = "Leisurely"; }

    public State_MovementSpeedLeisurely(StateMachine machine) { }

    public override bool CanAccess(StateMachine mech)
    {
        return true;
    }

    public override void Start(StateMachine mech)
    {
        canLeave = true;
        // Start everything before base since it starts update.
        base.Start(mech);
        //isExiting = false;
        //mech.currentstate0 = this;
    }
}
