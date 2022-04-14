using System;
using System.Collections.Generic;

namespace SolitaireHelperModels
{

    public class CardDeck
    {
        public List<Card> Deck { get; set; }
        public CardDeck()
        {
            Deck = NewUnshuffledDeck();
        }
        public List<Card> NewUnshuffledDeck()
        {
            List<Card> cardDeck = new List<Card>();
            for (int j = 1; j <= 4; j++)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Console.Write("i:" + i.ToString() +  " j:" +  j.ToString() + "\n");
                    Card card = new Card(suit: j, rank: i, visible: false);
                    cardDeck.Add(card);
                }
            }
            /*
            for (int i = (int)Suits.HEARTS; i <= (int)Suits.SPADES; i++)
            {
                Card newCard = new Card()
                {
                    Suit = i,
                    Rank = 1,
                    Visible = false
                };
                cardDeck.Add(newCard);
                for (int j = 2; j <= 9; j++)
                {
                    Card card = new Card()
                    {
                        Suit = i,
                        Rank = j,
                        Visible = false
                    };
                    cardDeck.Add(card);
                }
                Card ten = new Card()
                {
                    Suit = i,
                    Rank = 10,
                    Visible = false
                };
                cardDeck.Add(ten);
                Card knight = new Card()
                {
                    Suit = i,
                    Rank = 11,
                    Visible = false
                };
                cardDeck.Add(knight);
                Card queen = new Card()
                {
                    Suit = i,
                    Rank = 12,
                    Visible = false
                };
                cardDeck.Add(queen);
                Card king = new Card()
                {
                    Suit = i,
                    Rank = 13,
                    Visible = false
                };
                cardDeck.Add(king);
            } */

            return cardDeck;
        }
        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = Deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Deck[k];
                Deck[k] = Deck[n];
                Deck[n] = value;
            }
        }
        public void PrintDeck()
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                Console.WriteLine(Deck.ToArray()[i].ToString());
            }
        }
    }
}
