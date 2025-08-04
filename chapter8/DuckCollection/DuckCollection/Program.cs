List<Duck> ducks = new List<Duck>()
{
    new Duck() { Kind = KindOfDuck.Loon, Size = 115},
    new Duck() { Kind = KindOfDuck.Loon, Size = 1115},
    new Duck() { Kind = KindOfDuck.Mallard, Size = 22},
    new Duck() { Kind = KindOfDuck.Muscovy, Size = 222},
};

ducks.Sort();
PrintDucks(ducks);


void PrintDucks(List<Duck> ducks)
{
    foreach (Duck duck in ducks)
    {
        Console.WriteLine($"{duck.Size} inch {duck.Kind}");
    }
}