using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Classes;

public abstract class Piece
{
    protected Texture2D texture;

    public virtual List<Square> GetLegalMoves()
    {
        return null;
    }
}