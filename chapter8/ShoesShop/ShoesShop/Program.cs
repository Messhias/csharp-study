ShoeCloset shoeCloset = new ShoeCloset();

while (true)
{
    shoeCloset.PrintShoes();
    Console.WriteLine("press 'a' to add or 'r' to remove shoes.");
    char key = Console.ReadKey().KeyChar;

    switch (key)
    {
        case 'a':
        case 'A':
            shoeCloset.AddShoe();
            break;
        case 'r':
        case 'R':
            shoeCloset.RemoveShoe();
            break;
    }
}