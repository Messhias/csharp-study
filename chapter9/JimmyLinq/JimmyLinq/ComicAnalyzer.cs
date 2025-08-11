namespace JimmyLinq;

public static class ComicAnalyzer
{
    private static PriceRange CalculatePriceRange(Comics comics, IReadOnlyDictionary<int, decimal> prices)
    {
        return prices[comics.Issue] > 100 ? PriceRange.Expensive : PriceRange.Cheap;
    }

    public static IEnumerable<string> GetReviews(IEnumerable<Comics> catalog, IEnumerable<Review> reviews) =>
        catalog.Join(reviews, comic => comic.Issue, review => review.Issue,
            (comic, review) => $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score}");

    public static IEnumerable<IGrouping<PriceRange, Comics>> GroupComicsByPrice(IEnumerable<Comics> catalogs,
        IReadOnlyDictionary<int, decimal> prices) =>
        catalogs.OrderBy(comics => prices[comics.Issue])
            .GroupBy(comics => CalculatePriceRange(comics, prices))
            .Select(g => g);
}