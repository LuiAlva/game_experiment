using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MovementSpeed1 : StateMachine
{

    public SM_MovementSpeed1(PC_Main pc)
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
        stateList.Add("Idle", new State_MovementSpeedIdle());
        stateList.Add("Leisurely", new State_MovementSpeedLeisurely());
        stateList.Add("Hasty", new State_MovementSpeedHasty());
        stateList.Add("Sneaky", new State_MovementSpeedSneaky());
        stateList.Add("Weary", new State_MovementSpeedWeary());
    }
}
