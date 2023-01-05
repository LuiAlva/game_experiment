using UnityEngine;

public abstract class StatusEffect
{
    protected PC_Main PC;
    protected StatusEffects effectList;
    [SerializeField] public string Name { get; protected set; }
    [SerializeField] public float StartTime { get; protected set; }
    public float TimeLeft { get; protected set; }
    [SerializeField] public float Strength { get; protected set; }
    bool _updating = false;

    public virtual void Activate(PC_Main pc, StatusEffects EffectList)
    {
        PC = pc;
        effectList = EffectList;
        TimeLeft = StartTime;
        Start();
    }

    public virtual void Start() => _updating = true;
    public void Cancel() => TimeLeft = 0;

    public void SetTimeLeft(float time) => TimeLeft = time;

    public void ExtendTimeLeft(float timeToAdd) => TimeLeft = Mathf.Max(StartTime, timeToAdd + TimeLeft);

    public void Update()
    {
        if(!_updating) { return; }
        if(TimeLeft > 0) { TimeLeft -= Time.deltaTime; }
        else { _updating = false; kill(); }
    }

    protected virtual void kill()
    {
        effectList.RemoveEffect(this);
    }
}
