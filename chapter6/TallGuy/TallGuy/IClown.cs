public interface IClown
{
    public string FunnyThingIHave { get; }
    
    void Honk();
    void TalkAboutYourself();

    protected static Random random = new Random();
    private static int carCapacity = 12;

    public static int CarCapacity
    {
        get => carCapacity;
        set
        {
            if (value > 10)
            {
                carCapacity = value;
            }
            else
            {
                Console.Error.WriteLine($"Warning: CarCapacity {value} is too small.");
            }
        }
    }

    static string ClownCarDescription()
    {
        return $"A clown car with {random.Next(CarCapacity / 2, CarCapacity)} clowns";
    }
}