using System;

public class Health
{
    PC_Main PC;
    Stat constitution;
    public string Name = "Health";
    public Resource Values;

    public Health(PC_Main pc)
    {
        PC = pc;
        constitution = pc.Stats.Constitution;
        Values = new Resource();
        calcBaseHealthFromStat();
        Values.ChangeCurrentAmount(Values.MaxAmount);
        Values.SetupRegen(0.8f,20f,40f);
    }

    public void Update()
    {
        Values.Regenerate();
        updateHealthDisplay();
    }

    public void calcBaseHealthFromStat()
    {
        Values.StatValue = (constitution.Value * 12f);
        Values.Updated = true;
    }

    void updateHealthDisplay()
    {
        if (Values.Updated)
        {
            PC.TestUi.UpdateHealthText($"{Math.Truncate(Values.CurrentAmount)}/{Math.Truncate(Values.MaxAmount)}");
            Values.Updated = false;
        }
    }

}
