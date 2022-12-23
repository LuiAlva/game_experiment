using System;

public class Magic : Resource
{
    public Magic(PC_Main pc)
    {
        PC = pc;
        stat = pc.Stats.Intelligence;
        Values = new ResourceValue();
        name = "Magic";
        statMultiplier = 2.3f;
        calcBaseValueFromStat();
        Values.ChangeCurrentAmount(Values.MaxAmount);
        Values.SetupRegen(0.8f, 20f, 40f);
    }
    protected override void updateUI()
    {
        if (Values.Updated)
        {
            PC.TestUi.UpdateManaText($"{Math.Truncate(Values.CurrentAmount)}/{Math.Truncate(Values.MaxAmount)}");
            Values.Updated = false;
        }
    }
}
