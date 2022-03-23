namespace SolitaireHelper.Models
{
    public class Card
    {
        public int Id { get; set; }
        public char Suit { get; set; }
        public char Rank { get; set; }
        public bool Visible { get; set; }
        //public bool IsRed() { return Suit == Suit.HEARTS || Suit == Suit.DIAMONDS; }

        //public bool IsBlack() { return Suit == Suit.SPADES || Suit == Suit.CLUBS; }


    }

    public enum Suit
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