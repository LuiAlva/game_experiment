using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_MoveSpeed
{
    PC_Main PC;
    PC_Speed speed;
    bool activeSpeed = false;
    public EnumMoveSpeedStates CurrentState;
    public enum EnumMoveSpeedStates
    {
        Idle,
        Leisurely,
        Hasty,
        Sneaky,
        Weary
    }

    public SM_MoveSpeed(PC_Main pc)
    {
        PC = pc;
        speed = pc.Speed;
    }

    public void ChangeState(EnumMoveSpeedStates moveSpeedState)
    {
        if(CurrentState == moveSpeedState) { return; }
        switch (moveSpeedState.ToString())
        {
            case "Hasty":
                activeSpeed = true;
                speed.SetMovementSpeedStateMultipler(1.5f);
                break;
            case "Leisurely":
                if (!activeSpeed) { speed.SetMovementSpeedStateMultipler(1f); }
                else { return; }
                break;
            case "Sneaky":
                activeSpeed = true;
                speed.SetMovementSpeedStateMultipler(0.7f);
                break;
            case "Weary":
                activeSpeed = true;
                speed.SetMovementSpeedStateMultipler(0.5f);
                break;
            case "Idle":
                break;
            default:
                speed.SetMovementSpeedStateMultipler(1f);
                break;
        }
        CurrentState = moveSpeedState;
        PC.TestUi.UpdateMovementStateText(moveSpeedState.ToString());
    }

    public void ResetSpeedAction()
    {
        if(!activeSpeed) { return; }
        activeSpeed = false;
        ChangeState(EnumMoveSpeedStates.Leisurely);
    }
}
