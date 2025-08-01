// See https://aka.ms/new-console-template for more information

IClown tall = new TallGuy()
{
    Height = 90,
    Name = "Jon",
};

tall.TalkAboutYourself();
Console.Write($"The tall guy has {tall.FunnyThingIHave}");
tall.Honk();

class TallGuy : IClown
{
    public string Name;
    public int Height;

    public string FunnyThingIHave => "Big shoes";

    public void Honk()
    {
        Console.WriteLine("Honk honk!");
    }

    public void TalkAboutYourself()
    {
        Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
    }
}