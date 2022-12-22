public class PC_ActionAttack : ChargeAction
{
    public PC_ActionAttack(PC_Main pc)
    {
        PC = pc;
        resetTime = 2.3f;
    }

    public override void Activate()
    {
        base.Activate();
        PC.States.Movement.ChangeState(SM_Movement.Speeds.Hasty);
    }

    public override void End()
    {
        if (chargeActionComplete) { PC.States.Movement.ChangeMedium(SM_Movement.Mediums.Land); }
        else { PC.States.Movement.ReleaseStateLock(SM_Movement.Locks.Haste); }
        base.End();
    }

    protected override void chargeAction()
    {
        PC.States.Movement.ReleaseStateLock(SM_Movement.Locks.Haste);
        PC.States.Movement.ChangeMedium(SM_Movement.Mediums.Air);
        base.chargeAction();
    }
}
