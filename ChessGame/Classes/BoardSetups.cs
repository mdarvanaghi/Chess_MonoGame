using ChessGame.Utilities;

namespace ChessGame.Classes;

public struct BoardSetups
{
    // A1 - H8
    public static readonly Types.OwnedPiece[] StandardSetup =
    {
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Rook
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Knight
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Bishop
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Queen
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.King
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Bishop
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Knight
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Rook
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.White,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.None,
            PieceId = PieceConstants.Id.Empty
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new ()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Pawn
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Rook
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Knight
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Bishop
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Queen
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.King
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Bishop
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Knight
        },
        new()
        {
            Color = Types.Color.Black,
            PieceId = PieceConstants.Id.Rook
        }
    };
}