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
        statelist0 = new Dictionary<string, State>();
        PC = pc;
        AddStates();
        statelist0["Idle"].Start(this);
    }

    public override void Update()
    {
        if (PC.Movement.IsMoving) { ChangeState(statelist0["Moving"]); }
        else { ChangeState(statelist0["Idle"]); }
    }

    protected override void AddStates()
    {
        statelist0.Add("Idle", new PC_StateIdle());
        statelist0.Add("Moving", new PC_StateMoving());

        CurrentState = statelist0["Idle"];
    }
}
