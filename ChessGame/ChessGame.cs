using ChessGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame;

public class ChessGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _knightTexture;
    private Vector2 _ballPos;
    private float _ballSpeed;

    public ChessGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _ballPos = new Vector2(_graphics.PreferredBackBufferWidth / 2f, _graphics.PreferredBackBufferHeight / 2f);
        _ballSpeed = 100f;

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // TODO: use this.Content to load your game content here
        _knightTexture = Content.Load<Texture2D>(TextureUtility.GetChessPieceTexturePath(
            Types.Color.Black,
            Types.Piece.QUEEN,
            128,
            false));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.W))
        {
            _ballPos.Y -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.S))
        {
            _ballPos.Y += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            _ballPos.X -= _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            _ballPos.X += _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (_ballPos.X > _graphics.PreferredBackBufferWidth - _knightTexture.Width / 2f)
        {
            _ballPos.X = _graphics.PreferredBackBufferWidth - _knightTexture.Width / 2f;
        }
        else if (_ballPos.X < _knightTexture.Width / 2f)
        {
            _ballPos.X = _knightTexture.Width / 2f;
        }

        if (_ballPos.Y > _graphics.PreferredBackBufferHeight - _knightTexture.Height / 2f)
        {
            _ballPos.Y = _graphics.PreferredBackBufferHeight - _knightTexture.Height / 2f;
        }
        else if (_ballPos.Y < _knightTexture.Height / 2f)
        {
            _ballPos.Y = _knightTexture.Height / 2f;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(
            _knightTexture, 
            _ballPos,
            null,
            Color.White,
            0f,
            new Vector2(_knightTexture.Width / 2f, _knightTexture.Height / 2f),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
