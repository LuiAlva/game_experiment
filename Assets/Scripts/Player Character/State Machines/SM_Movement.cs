public class SM_Movement
{
    PC_Main PC;
    PC_Speed speed;
    public Speeds CurrentSpeed;
    public Mediums CurrentMedium;
    public string CurrentMovementName { get; private set; }
    bool[] speedLocks = new bool[] { false,false,false };
    int lastLockedLock = 2; // 0: Hasty, 1: Sneaky, 2: None
    float mediumSpeed = 1f, stateSpeed = 1f;

    public enum Mediums
    {
        Land,
        Water,
        Air
    }
    public enum Speeds
    {
        Idle,
        Leisurely,
        Hasty,
        Sneaky
    }

    public SM_Movement(PC_Main pc)
    {
        PC = pc;
        speed = pc.Speed;
        CurrentMedium = Mediums.Land;
        CurrentSpeed = Speeds.Idle;
    }

    public void ChangeMedium(Mediums medium)
    {
        if (CurrentMedium == medium) { return; }
        switch (medium.ToString())
        {
            case "Land":
                mediumSpeed = 1f;
                break;
            case "Water":
                mediumSpeed = 0.7f;
                break;
            case "Air":
                mediumSpeed = 1.4f;
                break;
            default:
                break;
        }
        CurrentMedium = medium;
        Update();
    }

    public void ChangeState(Speeds speed)
    {
        if (CurrentSpeed == speed) { return; }
        switch (speed.ToString())
        {
            case "Leisurely":
                if (speedLocks[2]) { return; }
                stateSpeed = 1f;
                lastLockedLock = 2;
                break;
            case "Hasty":
                speedLocks[0] = true;
                speedLocks[2] = true;
                lastLockedLock = 0;
                stateSpeed = 1.5f;
                break;
            case "Sneaky":
                speedLocks[1] = true;
                speedLocks[2] = true;
                lastLockedLock = 1;
                stateSpeed = 0.7f;
                break;
            case "Idle":
                break;
            default:
                stateSpeed = 1f;
                break;
        }
        CurrentSpeed = speed;
        Update();
    }
    public enum Locks { Haste, Sneak };

    public void ReleaseStateLock(Locks lockName)
    {
        int lockNum = (int)lockName;
        if (!speedLocks[lockNum]) { return; }
        speedLocks[lockNum] = false;
        speedLocks[2] = speedLocks[0] || speedLocks[1];
        if (speedLocks[2])
        {
            if (lockNum == 0) { ChangeState(Speeds.Sneaky); }
            else { ChangeState(Speeds.Hasty); }
        }
        else { ChangeState(Speeds.Leisurely); }
    }

    public void RevertSpeedToLeisurely()
    {
        if (PC.Movement.CurrentSpeed == 0f) { ChangeState(Speeds.Idle); }
        else if(!speedLocks[2]) { ChangeState(Speeds.Leisurely); }
        else if(speedLocks[0] && lastLockedLock != 1) { ChangeState(Speeds.Hasty); }
        else { ChangeState(Speeds.Sneaky); }
    }

    void Update()
    {
        if(CurrentSpeed == Speeds.Leisurely)
        {
            if (CurrentMedium == Mediums.Land) { CurrentMovementName = "Walking";  }
            else if (CurrentMedium == Mediums.Water) { CurrentMovementName = "Swimming"; }
            else if (CurrentMedium == Mediums.Air) { CurrentMovementName = "Hover"; }
        }
        else if(CurrentSpeed == Speeds.Hasty)
        {
            if (CurrentMedium == Mediums.Land) { CurrentMovementName = "Running"; }
            else if (CurrentMedium == Mediums.Water) { CurrentMovementName = "Hasty Swimming"; }
            else if (CurrentMedium == Mediums.Air) { CurrentMovementName = "Hover Boost"; }
        }
        else if(CurrentSpeed == Speeds.Sneaky)
        {
            if (CurrentMedium == Mediums.Land) { CurrentMovementName = "Crouching"; }
            else if (CurrentMedium == Mediums.Water) { CurrentMovementName = "Sneaky Swimming"; }
            else if (CurrentMedium == Mediums.Air) { CurrentMovementName = "Quiet Hovering"; }
        }
        else if (CurrentSpeed == Speeds.Idle)
        {
            if (CurrentMedium == Mediums.Land) { CurrentMovementName = "Standing"; }
            else if (CurrentMedium == Mediums.Water) { CurrentMovementName = "Wading"; }
            else if (CurrentMedium == Mediums.Air) { CurrentMovementName = "Idle Hover"; }
        }
        speed.SetMovementSpeedStateMultiplier(mediumSpeed * stateSpeed);
        PC.TestUi.UpdateMovementStateText(CurrentMovementName);
    }
}
