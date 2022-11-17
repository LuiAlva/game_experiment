using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    PC_Main PC;
    // Stats
    public Stat Constitution;
    public Stat Strength;
    public Stat Defense;
    public Stat Dexterity;
    public Stat Intelligence;

    public Stats(PC_Main pc)
    {
        Constitution = new Stat("Constitution");
        Strength = new Stat("Strength");
        Defense = new Stat("Defense");
        Dexterity = new Stat("Dexterity");
        Intelligence = new Stat("Intelligence");
        PC = pc;
    }

    public void SetupStats(float baseConstitution, float baseStrength, float baseDexterity, float baseIntelligence)
    {
        Constitution.SetBase(baseConstitution);
        Strength.SetBase(baseStrength);
        Dexterity.SetBase(baseDexterity);
        Intelligence.SetBase(baseIntelligence);
        Defense.SetBase(calcDefense());
    }

    public void Update()
    {
        UpdateResources();
    }

    void UpdateResources()
    {
        if(Constitution.Updated)
        {
            PC.Resources.Health.calcBaseHealthFromStat();
            PC.TestUi.UpdateConstitutionText($"{Constitution.Value}");
            Constitution.Updated = false;
        }
        if(Strength.Updated)
        {
            PC.TestUi.UpdateStrengthText($"{Strength.Value}");
            Defense.Updated = true;
            Strength.Updated = false;
        }
        if(Dexterity.Updated)
        {
            PC.TestUi.UpdateDexterityText($"{Dexterity.Value}");
            Defense.Updated = true;
            Dexterity.Updated = false;
        }
        if(Intelligence.Updated)
        {
            PC.TestUi.UpdateIntelligenceText($"{Intelligence.Value}");
            Intelligence.Updated = false;
        }
        if(Defense.Updated)
        {
            PC.TestUi.UpdateDefenseText($"{Defense.Value}");
            Defense.SetBase(calcDefense());
            Defense.Updated = false;
        }
    }

    float calcDefense() => Mathf.Max(1,(Constitution.Value / 2)) + Mathf.Max(1,(Dexterity.Value / 2));
}
