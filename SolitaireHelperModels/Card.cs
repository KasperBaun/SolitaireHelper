namespace SolitaireHelperModels
{
    public class Card
    {
        public int Suit { get; set; }
        public int Rank { get; set; }
        public bool Visible { get; set; }

        public Card(int suit, int rank, bool visible)
        {
            Suit = suit;
            Rank = rank;
            Visible = visible;
        }

        public override string ToString()
        {
            return "Card: " + RankAsString() +" of " + SuitAsString() + ", Visible: " + Visible; 
        }
        public bool IsBlack() {
            return Suit == 2 || Suit == 4;
        }
        public bool IsRed()
        {
            return Suit == 1 || Suit == 3;
        }
        public bool IsEqual(Card card)
        {
            return Suit.Equals(card.Suit) && Rank.Equals(card.Rank);
        }
        
        public string SuitAsString()
        { 
            switch (Suit)
            {
                case 1:
                    return "Hearts";
                case 2:
                    return "Clubs";
                case 3:
                    return "Diamonds";
                case 4:
                    return "Spades";
                default:
                    return "Something went wrong";
            }
        }
        public string RankAsString()
        {
            switch (Rank)
            {
                case 1:
                    return "Ace";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Knight";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return "Something went wrong";
            }
        }
        public string SuitAsChar()
        {
            switch (Suit)
            {
                case 1:
                    return "H";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "S";
                default:
                    return "Something went wrong";
            }
        }
        public string RankAsChar()
        {
            switch (Rank)
            {
                case 1:
                    return "A";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                case 6:
                    return "6";
                case 7:
                    return "7";
                case 8:
                    return "8";
                case 9:
                    return "9";
                case 10:
                    return "10";
                case 11:
                    return "K";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return "Something went wrong";
            }
        }
    }    
}