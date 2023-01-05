public class StatusEffectDefense : StatusEffect
{
    public override void Activate(PC_Main pc, StatusEffects EffectList)
    {
        Name = "Defense";
        StartTime = 10f;
        Strength = 2f;
        base.Activate(pc, EffectList);
    }

    public override void Start()
    {
        PC.Stats.Defense.AddToBonus(Strength);
        base.Start();
    }

    protected override void kill()
    {
        PC.Stats.Defense.AddToBonus(-Strength);
        base.kill();
    }
}
