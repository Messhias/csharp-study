using JimmyLinq;

var done = false;

while (!done)
{
    Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to exit");
    done = Console.ReadKey(true).KeyChar.ToString().ToUpper() switch
    {
        "G" => GroupComicsByPrice(),
        "R" => GetReviews(),
        _ => true
    };
}

return;

static bool GroupComicsByPrice()
{
    var groups = ComicAnalyzer.GroupComicsByPrice(Comics.Catalog, Comics.Prices);

    foreach (var group in groups)
    {
        Console.WriteLine($"{group.Key} comics:");
        foreach (var comic in group) Console.WriteLine($"#{comic.Issue} {comic.Name}: {Comics.Prices[comic.Issue]:c}");
    }

    return false;
}

static bool GetReviews()
{
    var reviews = ComicAnalyzer.GetReviews(Comics.Catalog, Comics.Reviews);
    foreach (var review in reviews) Console.WriteLine(review);

    return false;
}