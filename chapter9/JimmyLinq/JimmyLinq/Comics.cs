namespace JimmyLinq;

public class Comics
{
    public static readonly IEnumerable<Comics> Catalog = new List<Comics>
    {
        new() { Name = "Johnny America vs. the Pink", Issue = 6 },
        new() { Name = "Rock an Roll (limited edition)", Issue = 19 },
        new() { Name = "Woman's Work", Issue = 36 },
        new() { Name = "Hippie Madness (misprinted)", Issue = 57 },
        new() { Name = "Revenge of the new Wave Freak (damaged)", Issue = 68 },
        new() { Name = "Black monday", Issue = 74 },
        new() { Name = "Tribal Tattoo Madness", Issue = 83 },
        new() { Name = "The Death of the object", Issue = 97 }
    };

    public static readonly IReadOnlyDictionary<int, decimal> Prices = new Dictionary<int, decimal>
    {
        { 6, 360M },
        { 19, 500M },
        { 36, 650M },
        { 57, 13525M },
        { 68, 250M },
        { 74, 75M },
        { 83, 25.75M },
        { 97, 3525M }
    };

    public static readonly IEnumerable<Review> Reviews = new[]
    {
        new Review { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
        new Review { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
        new Review { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
        new Review { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
        new Review { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 }
    };

    public string Name { get; set; }
    public int Issue { get; set; }

    public override string ToString()
    {
        return $"{Name} (issue {Issue})";
    }
}