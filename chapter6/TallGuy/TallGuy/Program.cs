// See https://aka.ms/new-console-template for more information

IClown tall = new TallGuy()
{
    Height = 90,
    Name = "Jon",
};

tall.TalkAboutYourself();
Console.Write($"The tall guy has {tall.FunnyThingIHave}");
tall.Honk();
