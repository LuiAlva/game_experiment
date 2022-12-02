using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_ActionAttack : Action
{
    float timer = 0;
    float resetTime = 1.6f;
    bool timerFinish = false;
    bool active = false;

    bool chargeActionComplete = false;

    public PC_ActionAttack(PC_Main pc) { PC = pc; }

    public override void Activate()
    {
        timerFinish = false;
        timer = resetTime;
        active = true;
        PC.Speed.ChangeSpeedState(PC_Speed.SpeedType.Sneaky);
        PC.Resources.Health.Resource.ChangeCurrentAmount(1.8f);
    }

    public void End()
    {
        PC.Speed.ChangeSpeedState(PC_Speed.SpeedType.Leisurely);
        chargeActionComplete = false;
        active = false;
    }

    public void Update()
    {
        if(!active || chargeActionComplete) { return; }
        if(timerFinish)
        {
            chargeAction();
        }
        else
        {
            if (timer > 0) { timer -= Time.deltaTime; }
            else { timerFinish = true; }
        }
    }

    void chargeAction()
    {
        Debug.Log("Charge Complete");
        PC.Speed.ChangeSpeedState(PC_Speed.SpeedType.Weary);
        chargeActionComplete = true;
    }
}
