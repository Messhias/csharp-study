Dictionary<int, RetiredPlayer> retiredPlayers = new Dictionary<int, RetiredPlayer>()
{
    {3, new RetiredPlayer("Babe Ruth", 1948)},
    {4, new RetiredPlayer("XPT", 1921)},
    {5, new RetiredPlayer("xRuth", 1948)},
    {6, new RetiredPlayer("!1uth", 1948)},
};

foreach (var key in retiredPlayers.Keys)
{
    RetiredPlayer player = retiredPlayers[key];
    Console.WriteLine($"{player.Name} #{key} retired in {player.YearRetired}");
}
