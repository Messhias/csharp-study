using Exercicise;

var filename = "deckofcards.txt";
Deck deck = new ();
deck.Shuffle();

for (int i = 0; i < deck.Count; i++)
{
    deck.RemoveAt(i);
    deck.WriteCards(filename);
}

Deck cardsToRead = new (filename);

foreach (var card in cardsToRead)
{
    Console.WriteLine(card.Name);
}