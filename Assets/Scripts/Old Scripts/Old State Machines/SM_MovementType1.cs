using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MovementType1 : StateMachine
{
    //Contains:
    //• Stand
    //• Crouch
    //• Crawl
    //• Swim
    //• Hover
    //• Dodge
    //• Jump
    public SM_MovementType1(PC_Main pc)
    {
        PC = pc;
        addState();
        CurrentState = stateList["Idle"];
        CurrentState.Start(this);
    }

    public override void Update()
    {

    }

    protected override void addState()
    {
        stateList.Add("Idle", new PC_StateIdle());
        stateList.Add("Moving", new PC_StateMoving());
    }
}
