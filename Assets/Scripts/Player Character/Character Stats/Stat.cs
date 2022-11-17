using UnityEngine;

public class Stat
{
    public string Name = "???";
    public float Value { get { return BaseValue + BonusValue; } }
    float BaseValue = 0f;
    float BonusValue = 0f;
    public bool Updated = true;

    public Stat(string name) { Name = name; }

    public void SetBase(float baseValue)
    {
        BaseValue = Mathf.Clamp(baseValue, 1, 1000);
        Updated = true;
    }

    public void SetBaseAndBonus(float baseValue, float bonusValue)
    {
        BaseValue = Mathf.Clamp(baseValue, 1, 1000);
        BonusValue = Mathf.Clamp(bonusValue, (BaseValue - 1) * -1, 1000);
        Updated = true;
    }

    public void AddToBase(float amount)
    {
        BaseValue += amount;
        BaseValue = Mathf.Clamp(BaseValue, 1, 1000);
        Updated = true;
    }

    public void AddToBonus(float amount)
    {
        BonusValue += amount;
        BonusValue = Mathf.Clamp(BonusValue, (BaseValue - 1) * -1, 1000);
        Updated = true;
    }
}
