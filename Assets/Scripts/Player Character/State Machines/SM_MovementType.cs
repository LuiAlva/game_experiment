using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MovementType : StateMachine
{
    //Contains:
    //• Stand
    //• Crouch
    //• Crawl
    //• Swim
    //• Hover
    //• Dodge
    //• Jump
    public SM_MovementType(PC_Main pc)
    {
        stateList = new Dictionary<string, State>();
        PC = pc;
        AddStates();
        stateList["Idle"].Start(this);
    }

    public override void Update()
    {
        if (PC.Movement.IsMoving) { ChangeState(stateList["Moving"]); }
        else { ChangeState(stateList["Idle"]); }
    }

    protected override void AddStates()
    {
        stateList.Add("Idle", new PC_StateIdle());
        stateList.Add("Moving", new PC_StateMoving());

        CurrentState = stateList["Idle"];
    }
}
