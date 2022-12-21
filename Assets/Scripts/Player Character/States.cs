using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    public SM_Movement Movement;

    public States(PC_Main pc)
    {
        Movement = new SM_Movement(pc);
    }
}
