using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MovementSpeed : StateMachine
{
    //Contains:
    //• Idle
    //• Move
    //• Dash
    public SM_MovementSpeed(PC_Main pc)
    {
        PC = pc;
        AddStates();
    }
    protected override void AddStates()
    {
        statelist0.Add("Idle", new PC_StateIdle());
        statelist0.Add("Attacking", new PC_StateAttacking());
        CurrentState = statelist0["Idle"];
    }

    public override void Update()
    {
    }
}
