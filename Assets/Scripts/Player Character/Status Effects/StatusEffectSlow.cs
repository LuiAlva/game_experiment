public class StatusEffectSlow : StatusEffect
{
    public override void Activate(PC_Main pc, StatusEffects EffectList)
    {
        Name = "Slow";
        StartTime = 4.6f;
        Strength = 0.5f;
        base.Activate(pc, EffectList);
    }

    public override void Start()
    {
        PC.Speed.AddSpeedPercentage(-Strength);
        base.Start();
    }

    protected override void kill()
    {
        PC.Speed.AddSpeedPercentage(Strength);
        base.kill();
    }
}
