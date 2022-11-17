using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Speed
{
    Stat Dexterity;

    float _movementTypeSpeed;

    public PC_Speed(PC_Main pc)
    {
        Dexterity = pc.Stats.Dexterity;
        _movementTypeSpeed = 1f;
    }

    public float GetCurrentSpeed()
    {
        return speedFromDexterity() * _movementTypeSpeed;
    }

    public void SetBaseSpeed(float moveTypeSpeed)
    {
        _movementTypeSpeed = moveTypeSpeed;
    }

    float speedFromDexterity()
    {
        return ((((float)Math.Truncate(Dexterity.Value / 2)) * 0.1f) + 2.8f);
    }


}
