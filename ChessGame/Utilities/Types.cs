namespace ChessGame.Utilities;

public static class Types
{
    public enum Color
    {
        White,
        Black
    }

    public class Piece
    {
        public const string PAWN = "pawn";
        public const string KNIGHT = "knight";
        public const string BISHOP = "bishop";
        public const string ROOK = "rook";
        public const string KING = "king";
        public const string QUEEN = "queen";
    }
}