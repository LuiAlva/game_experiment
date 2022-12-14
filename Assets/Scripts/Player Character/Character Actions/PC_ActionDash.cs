using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_ActionDash : Action
{
    public PC_ActionDash(PC_Main pc) { PC = pc; }
    public override void Activate()
    {
        PC.States.MovementSpeedStates.ChangeState(SM_MoveSpeed.EnumMoveSpeedStates.Hasty);
        PC.Resources.Health.Resource.ChangeCurrentAmount(-10);
    }

    public void End()
    {
        PC.States.MovementSpeedStates.ResetSpeedAction();
    }

}
