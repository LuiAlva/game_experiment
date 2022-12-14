using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_StateMoving : State1
{
    public PC_StateMoving()
    {
        Name = "Moving";
    }
    
    public override bool CanAccess(StateMachine mech)
    {
        return true;
    }

    public override void Start(StateMachine mech)
    {
        canLeave = true;
        base.Start(mech);
    }
}
