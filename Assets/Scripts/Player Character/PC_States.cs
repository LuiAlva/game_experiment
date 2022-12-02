using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_States
{
    public PC_Main PC;

    public SM_MovementSpeed MovementSpeedMachine = null;
    public SM_MovementType MovementTypeMachine = null;
    public StateMachine Action = null;

    public PC_States(PC_Main pc)
    {
        PC = pc;
        MovementSpeedMachine = new SM_MovementSpeed(pc);
        MovementTypeMachine = new SM_MovementType(pc);
    }

    public void Update()
    {
        MovementSpeedMachine?.Update();
        MovementTypeMachine?.Update();
    }
}
