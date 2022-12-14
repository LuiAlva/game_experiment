using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MovementSpeedHasty : State1
{
    public State_MovementSpeedHasty() { Name = "Hasty"; }

    public State_MovementSpeedHasty(StateMachine machine) { }

    public override bool CanAccess(StateMachine mech)
    {
        return true;
    }

    public override void Start(StateMachine mech)
    {
        canLeave = true;
        // Start everything before base since it starts update.
        base.Start(mech);
    }
}
