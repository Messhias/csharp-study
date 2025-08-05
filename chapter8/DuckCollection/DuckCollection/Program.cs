List<Duck> ducks = new List<Duck>()
{
    new Duck() { Kind = KindOfDuck.Loon, Size = 115},
    new Duck() { Kind = KindOfDuck.Loon, Size = 1115},
    new Duck() { Kind = KindOfDuck.Mallard, Size = 22},
    new Duck() { Kind = KindOfDuck.Muscovy, Size = 222},
};

// IComparer<Duck> comparer = new DuckCompareBySize(); // uncomment if you want to compare by size
// IComparer<Duck> comparer = new DuckComparerByKind();

DuckComparer  comparer = new DuckComparer();

comparer.SortBy = SortCriteria.SizeThenKind;
ducks.Sort(comparer);

PrintDucks(ducks);

Console.WriteLine("------");

comparer.SortBy = SortCriteria.KindThenSize;
ducks.Sort(comparer);
PrintDucks(ducks);

List<Duck> ducksTwo = new List<Duck>()
{
    new Duck() { Kind = KindOfDuck.Mallard, Size = 17},
    new Duck() { Kind = KindOfDuck.Muscovy, Size = 18},
    new Duck() { Kind = KindOfDuck.Loon, Size = 19},
    new Duck() { Kind = KindOfDuck.Mallard, Size = 20},
    new Duck() { Kind = KindOfDuck.Loon, Size = 21},
};

IEnumerable<Bird> upCastBirds = ducksTwo;

Bird.FlyWay(upCastBirds.ToList(), "Norway");


void PrintDucks(List<Duck> ducks)
{
    foreach (Duck duck in ducks)
    {
        Console.WriteLine($"{duck}");
    }
}