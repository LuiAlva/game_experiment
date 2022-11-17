using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_StateAttacking : State
{
    public PC_StateAttacking()
    {
        Name = "Attacking";
    }
    public override bool CanAccess(StateMachine manager)
    {
        return true;
    }

    public override void Start(StateMachine manager)
    {
        // Start everything before base since it starts update.
        base.Start(manager);
    }
}
