using System.Collections.Generic;
using ChessGame.Utilities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Classes;

public static class PieceConstants
{
    public static string[] TextureName =
    {
        "",
        "pawn",
        "knight",
        "bishop",
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