using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Resources
{
    PC_Main PC;
    public Health Health;

    public PC_Resources(PC_Main pc)
    {
        PC = pc;
        Health = new Health(PC);
    }

    public void Update()
    {
        Health.Update();
    }
}
