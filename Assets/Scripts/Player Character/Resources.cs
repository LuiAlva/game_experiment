public class Resources
{
    PC_Main PC;
    public Health Health;
    public Magic Magic;

    public Resources(PC_Main pc)
    {
        PC = pc;
        Health = new Health(PC);
        Magic = new Magic(PC);
    }

    public void Update()
    {
        Health.Update();
        Magic.Update();
    }
}
