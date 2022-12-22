using System;
using UnityEngine;

public  class Resource
{
    public float StatValue { get; set; }
    public float CurrentAmount = 0f;
    public float MaxAmount { get { return StatValue + BonusMaxAmount; } }
    public bool Updated = true;
    public float Overflow = 0f;

    //Regen
    public bool NoRegen = false;
    bool isRegenerating = false;
    float regenAmount = 0.8f;
    float regenTime = 0f;
    float regenTimer = 0f;
    float regenDelayTime = 30.5f;

    //Bonus
    public float BonusMaxAmount = 0f;
    public float BonusRegenAmount = 0f;
    public float BonusRegenTime = 0f;
    public float BonusRegenDelayTime = 0f;

    public Resource()
    {
    }

    public void Setup()
    {

    }

    public void SetupRegen(float regenAmountAtEndOfTimer, float timeUntilRegen, float timeDelayRegenAfterUsingResource)
    {
        regenAmount = regenAmountAtEndOfTimer;
        regenTime = timeUntilRegen;
        regenDelayTime = timeDelayRegenAfterUsingResource;
    }

    public void Regenerate()
    {
        if (NoRegen || isMax()) { return; }

        if(!isRegenerating)
        {
            if (regenTimer > 0)
            {
                regenTimer -= Time.fixedDeltaTime;
            }
            else { isRegenerating = true; }
        }
        else
        {
            if (regenTimer > 0)
            {
                regenTimer -= Time.fixedDeltaTime;
            }
            else { ChangeCurrentAmount(regenAmount + BonusRegenAmount); calcRegenTime(); }
        }
    }

    public void ChangeCurrentAmount(float amount)
    {
        CurrentAmount += amount;
        if (amount < 0) { delayRegeneration(); }
        if (CurrentAmount > MaxAmount) { CurrentAmount = MaxAmount; delayRegeneration(); }
        else if (CurrentAmount < 0) { Overflow += Math.Abs(CurrentAmount); CurrentAmount = 0; }
        Updated = true;
    }

    void delayRegeneration() { isRegenerating = false; calcRegenDelayTime(); }

    void calcRegenTime()
    {
        regenTimer = regenTime - BonusRegenTime;
        if (regenTimer < 2f) { regenTimer = 2f; }
    }

    void calcRegenDelayTime()
    {
        regenTimer = regenDelayTime - BonusRegenDelayTime;
        if (regenTimer < 0.1f) { regenTimer = 0.1f; }
    }

    bool isMax() => CurrentAmount == MaxAmount;
}
