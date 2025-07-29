using System;

namespace SloppyJoe;

public class MenuItem
{
    public static Random Random = new Random();

    public string[] Proteins = { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu"};
    
    public string[] Condiments = { "yellow mustard", "brow mustard", 
        "honey mustard", "mayo", "relish", "french dressing"};

    public string[] Breads = { "rye", "white", "wheat", "pumpernickel", "a roll"};

    public string Description = "";
    public string Price;

    public void Generate()
    {
        string randomProtein = Proteins[Random.Next(0, Proteins.Length)];
        string randomCondiment = Condiments[Random.Next(0, Condiments.Length)];
        string randomBread = Breads[Random.Next(0, Breads.Length)];
        
        Description += $"{randomProtein} with  {randomCondiment} on {randomBread}";
        
        decimal bucks = Random.Next(1, 5);
        decimal cents =  Random.Next(1, 98);
        decimal price = bucks + cents + 0.1M;
        Price = price.ToString("c");
    }
}