public class FunnyFunny : IClown
{
    private string _funnyThingIHave;

    public string FunnyThingIHave
    {
        get { return _funnyThingIHave; }
    }

    public void Honk()
    {
        Console.WriteLine("Hi kids!");
    }

    public void TalkAboutYourself()
    {
        Console.WriteLine($"Hi Kids! I have {FunnyThingIHave}");
    }

    public FunnyFunny(string funnyThingIHave)
    {
        _funnyThingIHave = funnyThingIHave;
    }
}