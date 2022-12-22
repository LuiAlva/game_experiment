public abstract class Action
{
    public PC_Main PC;
    public string Name { get; }

    public virtual bool CanActivate() => true;
    public abstract void Activate();
    public abstract void End();

}
