namespace ChessGame.Classes;

public static class PieceConstants
{
    public static string[] TextureName =
    {
        "",
        "pawn",
        "bishop",
        "knight",
        "rook",
        "queen",
        "king"
    };

    public enum Id
    {
        Empty,
        Pawn,
        Bishop,
        Knight,
        Rook,
        Queen,
        King,
        Count
    }

    public static int[] Value =
    {
        0, // Empty
        1, // Pawn
        3, // Bishop
        3, // Knight
        5, // Rook
        9, // Queen
        0, // King
    };
}