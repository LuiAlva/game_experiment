using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_States
{
    public PC_Main PC;

    public StateMachine MovementStateMachine = null;
    public StateMachine Action = null;

    public PC_States(PC_Main pc)
    {
        PC = pc;
        MovementStateMachine = new SM_MovementType(pc);
    }

    public void Update()
    {
        if (MovementStateMachine == null) { return; }
        MovementStateMachine.Update();
    }
}
