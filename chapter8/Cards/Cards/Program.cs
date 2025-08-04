
Random random = new Random();

Cards card = new((Values)random.Next(1, 14), (Suits)random.Next(4));

Console.WriteLine(card.Name);

List<Cards> cards = new List<Cards>();

for (int i = 0; i < 10; i++)
{
    cards.Add(new((Values)random.Next(1, 14), (Suits)random.Next(4)));
}