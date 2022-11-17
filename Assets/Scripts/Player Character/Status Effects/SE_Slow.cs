using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Slow : StatusEffect
{
    public SE_Slow()
    {
        Name = "Slow";
    }
    public override bool CanAccess(StatusEffects manager)
    {
        return true;
    }

    public override void Start(StatusEffects manager)
    {
        // Start everything before base since it starts update.
        base.Start(manager);
    }

    public override void Update()
    {
        if (IsExiting) { return; }
        else
        {

        }
    }
}
