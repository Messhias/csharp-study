var listOfObjects = new List<PrintWhenGetting>();

for (var i = 0; i < 5; i++)
{
    listOfObjects.Add(new PrintWhenGetting { InstanceNumber = i });
}

Console.WriteLine("Set up the query.");

var result = from o in listOfObjects
    select o.InstanceNumber;

var immediate = result.ToList();

Console.WriteLine("Run the foreach");
foreach (var i in immediate)
{
    Console.WriteLine($"Writing #{i}");
}

class PrintWhenGetting
{
    private readonly int _instanceNumber;

    public int InstanceNumber
    {
        init => _instanceNumber = value;
        get
        {
            Console.WriteLine($"Getting #{_instanceNumber}");
            return _instanceNumber;
        }
    }
}