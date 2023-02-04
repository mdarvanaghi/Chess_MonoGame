using ChessGame.Classes;
using ChessGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class ChessGameRunner : Game
{
    private GraphicsDeviceManager _graphicsDeviceManager;

    private ChessGameManager chessGameManager;

    private Color _backgroundColor = new(49, 46, 43);

    public ChessGameRunner()
    {
        _graphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ChessGameRenderer.ChessGameRenderConfig renderConfig = new(
            GraphicsDevice,
            128,
            true,
            new Color(240, 217, 181),
            new Color(181, 136, 99));
        chessGameManager = new ChessGameManager(renderConfig);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        chessGameManager.LoadContent(Content);
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
        chessGameManager.UnloadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        chessGameManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_backgroundColor);

        // TODO: Add your drawing code here
        chessGameManager.Draw(_graphicsDeviceManager);

        base.Draw(gameTime);
    }
}
