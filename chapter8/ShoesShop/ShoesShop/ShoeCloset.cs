public class ShoeCloset
{
    private readonly List<Shoe> _shoes =  new List<Shoe>();

    public void PrintShoes()
    {
        if (_shoes.Count == 0)
        {
            Console.WriteLine("\nThe shoe closet is empty.");
        }
        else
        {
            Console.WriteLine("\nThe shoe closet contains:");
            int i = 0;
            foreach (Shoe shoe in _shoes)
            {
                Console.WriteLine($"Shoe {i++}: {shoe.Description}");
            }
        }
    }

    public void AddShoe()
    {
        Console.WriteLine("Add a shoe to the shoe closet.");
        for (int i = 0; i < 6; i++)
        {
            Style styleName = (Style)i;
            Console.WriteLine($"Press {i} to add a {styleName}");
        }
        
        Console.WriteLine("Enter a style:");

        if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style)) return;
        
        
        Console.WriteLine("Enter the color");
        string color = Console.ReadLine();
        Shoe shoe = new Shoe((Style)style, color);
        _shoes.Add(shoe);
    }

    public void RemoveShoe()
    {
        Console.WriteLine("Enter shoe number to remove");
        if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) ||
            (shoeNumber < 1 || shoeNumber > _shoes.Count)) return;
        
        
        Console.WriteLine($"\nRemoving {_shoes[shoeNumber - 1].Description}");
        _shoes.RemoveAt(shoeNumber - 1);
    }
}
