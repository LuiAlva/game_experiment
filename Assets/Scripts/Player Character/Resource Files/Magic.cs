using System;

public class Magic
{
    PC_Main PC;
    Stat intelligence;
    public Resource Values;

    public Magic(PC_Main pc)
    {
        PC = pc;
        intelligence = pc.Stats.Intelligence;
        Values = new Resource();
        calcBaseMagicFromStat();
        Values.ChangeCurrentAmount(Values.MaxAmount);
        Values.SetupRegen(0.8f, 20f, 40f);
    }

    public void Update()
    {
        Values.Regenerate();
        updateMagicDisplay();
    }

    public void calcBaseMagicFromStat()
    {
        Values.StatValue = (intelligence.Value * 2.6f);
        Values.Updated = true;
    }

    void updateMagicDisplay()
    {
        if (Values.Updated)
        {
            PC.TestUi.UpdateManaText($"{Math.Truncate(Values.CurrentAmount)}/{Math.Truncate(Values.MaxAmount)}");
            Values.Updated = false;
        }
    }
}
