using ChessGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Classes;

public class ChessGameManager
{
    private Board _board;
    private ChessGameLogicHandler _logicHandler;
    private ChessGameRenderer _renderer;

    public ChessGameManager(
        ChessGameRenderer.ChessGameRenderConfig renderConfig, 
        Board.GameType gameType = Board.GameType.Standard)
    {
        _board = new Board(gameType);
        _renderer = new ChessGameRenderer(renderConfig);
    }

    public void LoadContent(ContentManager contentManager)
    {
        _renderer.LoadTextures(contentManager);
    }

    public void UnloadContent()
    {
        _renderer.UnloadTextures();
    }

    public void Draw(GraphicsDeviceManager graphicsDeviceManager)
    {
        _renderer.DrawBoard(_board, graphicsDeviceManager);
    }
}