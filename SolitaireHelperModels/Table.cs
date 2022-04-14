using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelperModels
{
    public class Table
    {
        public List<Pile> Tableaus { get; set; }
        public List<Pile> Foundations { get; set; }
        public Pile Talon { get; set; }   
        public Pile Stock { get; set; }
        public List<Card> Deck { get; set; }
        private List<Move> MovesList { get; set; }

        public Table(List<Card> deck)
        {
            Deck = deck;
            InstantiateTable();
        }

        /* Creates a new deck of shuffled cards and assigns them to their respective lists (tableaus, foundations, stock, talon) */
        private void InstantiateTable()
        {
            if (Deck.Count != 52)
                Console.WriteLine("Error with Deck @ Table.cs - InstatiateTable() - not 52 cards in deck!");
            PrintDeck();
            // Stock
            Stock = new Pile(numberOfCards: 28)
            {
                Type = 0
            };
            Stock.PushCards(Deck.GetRange(0, 24));
            //Deck.RemoveRange(0, 7);

            // Talon
            Talon = new Pile(numberOfCards: 0)
            {
                Type = 12
            };
            //Talon.PushCards(Deck.GetRange(7, 24));
            //Deck.RemoveRange(0, 24);

            // Tableaus
            Pile T1 = new Pile(numberOfCards: 1)
            {
                Type = 1
            };
            T1.PushCards(Deck.GetRange(24, 1));
            T1.GetCards()[0].Visible = true;
            //Deck.RemoveRange(0, 1);
            Tableaus.Add(T1);

            Pile T2 = new Pile(numberOfCards: 2)
            {
                Type = 2
            };
            T2.PushCards(Deck.GetRange(25, 2));
            T2.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 2);
            Tableaus.Add(T2);

            Pile T3 = new Pile(numberOfCards: 3)
            {
                Type = 3
            };
            T3.PushCards(Deck.GetRange(27, 3));
            T3.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 3);
            Tableaus.Add(T3);

            Pile T4 = new Pile(numberOfCards: 4)
            {
                Type = 4
            };
            T4.PushCards(Deck.GetRange(30, 4));
            T4.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 4);
            Tableaus.Add(T4);

            Pile T5 = new Pile(numberOfCards: 5)
            {
                Type = 5
            };
            T5.PushCards(Deck.GetRange(34, 5));
            T5.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 5);
            Tableaus.Add(T5);

            Pile T6 = new Pile(numberOfCards: 6)
            {
                Type = 6
            };
            T6.PushCards(Deck.GetRange(39, 6));
            T6.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 6);
            Tableaus.Add(T6);

            Pile T7 = new Pile(numberOfCards: 7)
            {
                Type = 7
            };
            T7.PushCards(Deck.GetRange(45, 7));
            T7.GetCards().FindLast(c => c != null).Visible = true;
            //Deck.RemoveRange(0, 7);
            Tableaus.Add(T7);

            Pile F1 = new Pile(numberOfCards: 0)
            {
                Type = 8
            };
            Foundations.Add(F1);

            Pile F2 = new Pile(numberOfCards: 0)
            {
                Type = 9
            };
            Foundations.Add(F2);

            Pile F3 = new Pile(numberOfCards: 0)
            {
                Type = 10
            };
            Foundations.Add(F3);

            Pile F4 = new Pile(numberOfCards: 0)
            {
                Type = 11
            };
            Foundations.Add(F4);

        }

        public void PrintTable()
        {
            Console.WriteLine("Talon: \n");
            foreach(Card card in Talon.GetCards())
            {
                Console.WriteLine(card.ToString());
            }
        }

        public void PrintDeck()
        {
            foreach (Card card in Deck)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
