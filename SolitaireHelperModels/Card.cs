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
            return "Card: " + SuitAsString(Suit) + RankAsString(Rank) + ", Visible: " + Visible; 
        }
        public bool IsBlack() {
            return Suit == (int)Suits.SPADES || Suit == (int)Suits.CLUBS;
        }
        public bool IsRed()
        {
            return Suit == (int)Suits.HEARTS || Suit == (int)Suits.DIAMONDS;
        }
        public bool IsEqual(Card card)
        {
            return Suit.Equals(card.Suit) && Rank.Equals(card.Rank);
        }
        
        public string SuitAsString(int suit)
        { 
            switch (suit)
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
        public string RankAsString(int rank)
        {
            switch (rank)
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
    }

    public enum Suits
    {
        HEARTS = 1,
        CLUBS = 2,
        DIAMONDS = 3,
        SPADES = 4
    }
    public enum FaceValue
    {
        NULL = 0,
        ONE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        KNIGHT = 11,
        QUEEN = 12,
        KING = 13
    }
}