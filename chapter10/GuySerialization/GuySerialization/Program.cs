using System.Text.Json;

var guys = new List<Guy>
{
    new()
    {
        Name = "Bob",
        Clothes = new Outfit
        {
            Top = "t-shirt",
            Bottom = "jeans"
        },
        Hair = new HairStyle
        {
            Color = HairColor.Red,
            Length = 3.5f
        }
    },
    new()
    {
        Name = "Joe",
        Clothes = new Outfit
        {
            Top = "polo",
            Bottom = "slacks"
        },
        Hair = new HairStyle
        {
            Color = HairColor.Gray,
            Length = 2.7f
        }
    }
};

var jsonString = JsonSerializer.Serialize(guys);
Console.WriteLine(jsonString);

var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);

foreach (var guy in copyOfGuys) Console.WriteLine("I deserialized this guy: {0}", guy);

var dudes = JsonSerializer.Deserialize<Stack<Dude>>(jsonString);
while (dudes.Count > 0)
{
    var dude = dudes.Pop();
    Console.WriteLine($"Next duded: {dude.Name} with {dude.Hair} hair");
}

Console.WriteLine(JsonSerializer.Serialize(3));
Console.WriteLine(JsonSerializer.Serialize((long)-3));
Console.WriteLine(JsonSerializer.Serialize((byte)0));
Console.WriteLine(JsonSerializer.Serialize(float.MaxValue));
Console.WriteLine(JsonSerializer.Serialize(float.MinValue));
Console.WriteLine(JsonSerializer.Serialize(true));
Console.WriteLine(JsonSerializer.Serialize("Elephant"));
Console.WriteLine(JsonSerializer.Serialize("Elephant".ToCharArray()));

internal class Dude
{
    public string Name { get; set; }
    public HairStyle Hair { get; set; }
}

internal class Guy
{
    public string Name { get; set; }
    public HairStyle Hair { get; set; }
    public Outfit Clothes { get; set; }

    public override string ToString()
    {
        return $"{Name} with {Hair} wearing {Clothes}";
    }
}

internal class Outfit
{
    public string Top { get; set; }
    public string Bottom { get; set; }

    public override string ToString()
    {
        return $"{Top} and {Bottom}";
    }
}

internal enum HairColor
{
    Auburn,
    Black,
    Blonde,
    Blue,
    Brown,
    Gray,
    White,
    Purple,
    Platinum,
    Red
}

internal class HairStyle
{
    public HairColor Color { get; set; }
    public float Length { get; set; }

    public override string ToString()
    {
        return $"{Length:0.0} inch {Color} hair";
    }
}