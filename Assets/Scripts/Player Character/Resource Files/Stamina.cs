using System;
using CustomExtensions;

public class Stamina : Resource
{
    public Stamina(PC_Main pc)
    {
        PC = pc;
        stat = pc.Stats.Dexterity;
        Values = new ResourceValue();
        name = "Stamina";
        statMultiplier = 10.43f;
        calcBaseValueFromStat();
        Values.ChangeCurrentAmount(Values.MaxAmount);
        Values.SetupRegen(0.8f, 20f, 40f);
    }
    protected override void updateUI()
    {
        if (Values.Updated)
        {
            PC.TestUi.StaminaText.LabeledText(name, $"{Math.Truncate(Values.CurrentAmount)}/{Math.Truncate(Values.MaxAmount)}");
            Values.Updated = false;
        }
    }
}
