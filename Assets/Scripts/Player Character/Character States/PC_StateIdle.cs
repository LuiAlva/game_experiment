using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_StateIdle : State
{
    public PC_StateIdle() { Name = "Idle"; }

    public PC_StateIdle(StateMachine machine) { }

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
