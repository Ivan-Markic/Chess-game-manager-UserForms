namespace ChessGameManager.Models
{
    public class ChessGame
    {
        public int IDChessGame { get; set; }
        public Person FirstPlayer { get; set; }
        public Person SecondPlayer { get; set; }
        public string GameLocation { get; set; }
    }
}
