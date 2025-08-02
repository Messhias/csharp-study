public class ScaryScary : FunnyFunny, IScaryClown
{
    private readonly int _scaryThingCount;
    public ScaryScary(string funnyThingIHave, int scaryThingCount) : base(funnyThingIHave)
    {
        _scaryThingCount = scaryThingCount;
    }

    public string ScaryThingIHave => _scaryThingCount + " spiders";

    public void ScareLittleChildren()
    {
        Console.WriteLine($"Bo! Gotcha! Look at my {ScaryThingIHave}");
    }
}