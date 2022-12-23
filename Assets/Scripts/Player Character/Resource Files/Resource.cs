public abstract class Resource
{
    protected PC_Main PC;
    protected Stat stat;
    protected string name = "???";
    protected float statMultiplier = 1f;
    public ResourceValue Values;
    public string Name => name;
    public virtual void Update()
    {
        Values.Regenerate();
        calcBaseValueFromStat();
        updateUI();
    }
    public virtual void calcBaseValueFromStat()
    {
        Values.SetBaseStat(stat.Value * statMultiplier);
    }
    protected abstract void updateUI();
}
