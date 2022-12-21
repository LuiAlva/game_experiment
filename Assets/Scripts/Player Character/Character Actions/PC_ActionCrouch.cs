using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_ActionCrouch : ChargeAction
{
    SM_Movement movement;

    public PC_ActionCrouch(PC_Main pc)
    {
        PC = pc;
        movement = pc.States.Movement;
    }

    public override void Activate()
    {
        base.Activate();
        movement.ChangeState(SM_Movement.Speeds.Sneaky);
    }

    public override void End()
    {
        movement.ReleaseStateLock(SM_Movement.Locks.Sneak);
        base.End();
    }

    protected override void chargeAction()
    {
        base.chargeAction();
    }
}
