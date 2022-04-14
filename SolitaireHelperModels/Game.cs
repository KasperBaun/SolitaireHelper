namespace SolitaireHelperModels
{
    public class Game
    {
        public string Id { get; set; }
        public string Player { get; set; }
        public string Date { get; set; }
        public string GameType { get; set; }
        public bool IsFinished { get; set; }

        public Table Table { get; set; }
        public Game(){}
    }
}