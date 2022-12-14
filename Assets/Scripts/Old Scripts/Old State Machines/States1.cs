using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States1
{
    public PC_Main PC;

    public SM_MovementSpeed1 MovementSpeedMachine = null;
    public SM_MovementType1 MovementTypeMachine = null;
    public StateMachine Action = null;

    public States1(PC_Main pc)
    {
        PC = pc;
        MovementSpeedMachine = new SM_MovementSpeed1(pc);
        MovementTypeMachine = new SM_MovementType1(pc);
    }

    public void Update()
    {
        MovementSpeedMachine?.Update();
        MovementTypeMachine?.Update();
    }
}
