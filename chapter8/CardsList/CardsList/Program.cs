while (true)
{
    Console.WriteLine("Enter number of cards (q to exit):");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "q" :
            case "Q":
                return;
        break;
    }

    if (int.TryParse(input, out int number))
    {
        List<Card>  cards = new List<Card>();
        for (int i = 0; i < number; i++)
        {
            Random random = new Random();
            Suits suit = (Suits)random.Next(1, 4);
            Values values = (Values)random.Next(1, 14);
            
            cards.Add(new Card(values, suit));
        }
        
        cards.Sort(new CardComparerByValue());
        PrintCards(cards);
    }
    
    Console.WriteLine("----------------------");
}

void PrintCards(List<Card> cards)
{
    foreach (Card card in cards)
    {
        Console.WriteLine(card);
    }
}