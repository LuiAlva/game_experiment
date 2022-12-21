using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAction : Action
{
    float timer = 0;
    float resetTime = 1.6f;
    bool timerFinish = false;
    bool active = false;

    bool chargeActionComplete = false;

    public override void Activate()
    {
        timerFinish = false;
        timer = resetTime;
        active = true;
    }

    public override void End()
    {
        chargeActionComplete = false;
        active = false;
    }

    public void Update()
    {
        if (!active || chargeActionComplete) { return; }
        if (timerFinish)
        {
            chargeAction();
        }
        else
        {
            if (timer > 0) { timer -= Time.deltaTime; }
            else { timerFinish = true; }
        }
    }

    protected virtual void chargeAction()
    {
        chargeActionComplete = true;
    }
}
