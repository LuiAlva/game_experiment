using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_ActionDash : Action
{
    public PC_ActionDash(PC_Main pc) { PC = pc; }
    public override void Activate()
    {
        PC.Movement.SetSpeedActionMultiplier(1.8f);
        PC.Resources.Health.Resource.ChangeCurrentAmount(-10);
    }

    public void End()
    {
        PC.Movement.SetSpeedActionMultiplier(1);
    }

}
