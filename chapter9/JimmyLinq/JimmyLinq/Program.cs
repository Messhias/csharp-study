using JimmyLinq;

var done = false;

while (!done)
{
    Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to exit");
    switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
    {
        case "G":
            done = GroupComicsByPrice();
            break;
        case "R":
            done = GetReviews();
            break;
        default:
            done = true;
            break;
    }
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

public static class ComicAnalyzer
{
    private static PriceRange CalculatePriceRange(Comics comics)
    {
        return Comics.Prices[comics.Issue] > 100 ? PriceRange.Expensive : PriceRange.Cheap;
    }

    public static IEnumerable<string> GetReviews(IEnumerable<Comics> catalog, IEnumerable<Review> reviews)
    {
        return from comic in catalog
            join review in reviews on comic.Issue equals review.Issue
            select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score}";
    }

    public static IEnumerable<IGrouping<PriceRange, Comics>> GroupComicsByPrice(IEnumerable<Comics> catalogs,
        IReadOnlyDictionary<int, decimal> prices)
    {
        IEnumerable<IGrouping<PriceRange, Comics>> groups = from comics in catalogs
            orderby prices[comics.Issue]
            group comics by CalculatePriceRange(comics)
            into g
            select g;

        return groups
    }
}