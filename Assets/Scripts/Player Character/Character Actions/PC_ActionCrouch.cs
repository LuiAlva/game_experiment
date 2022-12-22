public class PC_ActionCrouch : Action
{
    SM_Movement movement;

    public PC_ActionCrouch(PC_Main pc)
    {
        PC = pc;
        movement = pc.States.Movement;
    }

    public override void Activate()
    {
        movement.ChangeState(SM_Movement.Speeds.Sneaky);
    }

    public override void End()
    {
        movement.ReleaseStateLock(SM_Movement.Locks.Sneak);
    }
}
