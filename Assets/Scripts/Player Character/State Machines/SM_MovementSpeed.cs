using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MovementSpeed : StateMachine
{
    //Contains:
    //• Idle
    //• Move
    //• Dash
    //• Sneak
    public SM_MovementSpeed(PC_Main pc)
    {
        PC = pc;
        AddStates();
    }
    protected override void AddStates()
    {
        stateList.Add("Idle", new PC_StateIdle());
        stateList.Add("Move", new PC_StateAttacking());
        CurrentState = stateList["Idle"];
    }

    public override void Update()
    {
    }
}
