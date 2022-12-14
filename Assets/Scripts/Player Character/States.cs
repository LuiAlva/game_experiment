using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    public SM_MoveSpeed MovementSpeedStates;

    public States(PC_Main pc)
    {
        MovementSpeedStates = new SM_MoveSpeed(pc);
    }
}
