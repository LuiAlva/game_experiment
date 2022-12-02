using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_ActionDash : Action
{
    public PC_ActionDash(PC_Main pc) { PC = pc; }
    public override void Activate()
    {
        PC.Speed.ChangeSpeedState(PC_Speed.SpeedType.Hasty);
        PC.Resources.Health.Resource.ChangeCurrentAmount(-10);
    }

    public void End()
    {
        PC.Speed.ChangeSpeedState(PC_Speed.SpeedType.Leisurely);
    }

}
