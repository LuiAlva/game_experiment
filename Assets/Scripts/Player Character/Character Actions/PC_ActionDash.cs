public class PC_ActionDash : Action
{
    public PC_ActionDash(PC_Main pc) { PC = pc; }
    public override void Activate()
    {
        PC.States.Movement.ChangeState(SM_Movement.Speeds.Hasty);
        PC.Resources.Health.Values.ChangeCurrentAmount(-10);
    }

    public override void End()
    {
        PC.States.Movement.ReleaseStateLock(SM_Movement.Locks.Haste);
    }

}
