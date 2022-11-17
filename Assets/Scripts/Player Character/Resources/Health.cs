using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    PC_Main PC;
    Stat constitution;
    public string Name = "Health";
    public Resource Resource;

    public Health(PC_Main pc)
    {
        PC = pc;
        constitution = pc.Stats.Constitution;
        Resource = new Resource();
        calcBaseHealthFromStat();
        Resource.ChangeCurrentAmount(Resource.MaxAmount);
        Resource.SetupRegen(0.8f,20f,40f);
    }

    public void Update()
    {
        Resource.Regenerate();
        updateHealthDisplay();
    }

    public void calcBaseHealthFromStat()
    {
        Resource.StatValue = (constitution.Value * 12f);
        Resource.Updated = true;
    }

    void updateHealthDisplay()
    {
        if (Resource.Updated)
        {
            PC.TestUi.UpdateHealthText($"{Math.Truncate(Resource.CurrentAmount)}/{Math.Truncate(Resource.MaxAmount)}");
            Resource.Updated = false;
        }
    }

}
