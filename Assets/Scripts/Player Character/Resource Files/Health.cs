using System;

public class Health : Resource
{
    public Health(PC_Main pc)
    {
        PC = pc;
        stat = pc.Stats.Constitution;
        Values = new ResourceValue();
        name = "Health";
        statMultiplier = 12.32f;
        calcBaseValueFromStat();
        Values.ChangeCurrentAmount(Values.MaxAmount);
        Values.SetupRegen(0.8f, 20f, 40f);
    }
    protected override void updateUI()
    {
        if (Values.Updated)
        {
            PC.TestUi.UpdateHealthText($"{Math.Truncate(Values.CurrentAmount)}/{Math.Truncate(Values.MaxAmount)}");
            Values.Updated = false;
        }
    }
}
