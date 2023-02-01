using ChessGame.Classes;

namespace ChessGame.Utilities;

public static class Types
{
    public enum Color
    {
        None,
        White,
        Black
    }

    public struct OwnedPiece
    {
        public Color Color;
        public PieceConstants.Id PieceId;
    }
}