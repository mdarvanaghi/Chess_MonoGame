using System;
using System.Collections.Generic;
using System.Linq;
using ChessGame.Utilities;

namespace ChessGame.Classes;

public class Board
{
    public enum GameType
    {
        Standard,
        Chess960
    }
    
    private Types.OwnedPiece[] _pieces;
    public Types.OwnedPiece[] Pieces => _pieces;

    public Board(GameType gameType = GameType.Standard)
    {
        switch (gameType)
        {
            case GameType.Standard:
                _pieces = BoardSetups.StandardSetup;
                break;
            case GameType.Chess960:
                // TODO: Implement Chess960 board generation
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameType), gameType, null);
        }
    }
}