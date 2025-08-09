public class Comic
{
    public static readonly IEnumerable<Comic> Catalog = new List<Comic>
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

    public string Name { get; set; }
    public int Issue { get; set; }

    public override string ToString()
    {
        return $"{Name} (issue {Issue})";
    }
}