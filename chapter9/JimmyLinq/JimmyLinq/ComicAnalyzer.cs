namespace JimmyLinq;

public static class ComicAnalyzer
{
    private static PriceRange CalculatePriceRange(Comics comics, IReadOnlyDictionary<int, decimal> prices)
    {
        return prices[comics.Issue] > 100 ? PriceRange.Expensive : PriceRange.Cheap;
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
            group comics by CalculatePriceRange(comics, prices)
            into g
            select g;

        return groups;
    }
}