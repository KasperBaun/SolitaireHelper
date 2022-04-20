using SolitaireHelperModels;

CardDeck Deck = new();
Console.WriteLine("Unsorted deck: \n");
Deck.PrintDeck();
Console.WriteLine("\nSorted deck: \n");
Deck.ShuffleDeck();
Deck.PrintDeck();
