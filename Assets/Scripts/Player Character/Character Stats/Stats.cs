using UnityEngine;
using CustomExtensions;

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
        Defense.SetBase(CalcDefense());
    }

    public void Update()
    {
        UpdateResources();
    }

    void UpdateResources()
    {
        if(Constitution.Updated)
        {
            PC.Resources.Health.calcBaseValueFromStat();
            PC.TestUi.ConstitutionText.LabeledText("Constitution", Constitution.Value.ToString());
            Constitution.Updated = false;
        }
        if(Strength.Updated)
        {
            PC.TestUi.StrengthText.LabeledText("Strength", Strength.Value.ToString());
            Defense.Updated = true;
            Strength.Updated = false;
        }
        if(Dexterity.Updated)
        {
            PC.Resources.Magic.calcBaseValueFromStat();
            PC.TestUi.DexterityText.LabeledText("Dexterity", $"{Dexterity.Value}");
            Defense.Updated = true;
            Dexterity.Updated = false;
        }
        if(Intelligence.Updated)
        {
            PC.Resources.Magic.calcBaseValueFromStat();
            PC.TestUi.IntelligenceText.LabeledText("Intelligence", Intelligence.Value.ToString());
            Intelligence.Updated = false;
        }
        if(Defense.Updated)
        {
            PC.TestUi.DefenseText.LabeledText("Defense", Defense.Value.ToString());
            Defense.SetBase(CalcDefense());
            Defense.Updated = false;
        }
    }

    float CalcDefense() => Mathf.Max(1,(Constitution.Value / 2)) + Mathf.Max(1,(Dexterity.Value / 2));
}
