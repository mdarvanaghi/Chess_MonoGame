using ChessGame.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGame.Classes;

public class ChessGameRenderer
{
    public class ChessGameRenderConfig
    {
        public GraphicsDevice GraphicsDevice;
        public int TextureResolution;
        public bool PieceShadows;

        public ChessGameRenderConfig(
            GraphicsDevice graphicsDevice,
            int textureResolution,
            bool pieceShadows)
        {
            GraphicsDevice = graphicsDevice;
            TextureResolution = textureResolution;
            PieceShadows = pieceShadows;
        }
    }
    
    private Texture2D[] _pieceTextures;
    private SpriteBatch _spriteBatch;
    private ChessGameRenderConfig _renderConfig;
    
    public ChessGameRenderer(ChessGameRenderConfig renderConfig)
    {
        _renderConfig = renderConfig;
    }
    
    public void LoadTextures(ContentManager contentManager)
    {
        _spriteBatch = new SpriteBatch(_renderConfig.GraphicsDevice);

        _pieceTextures = new Texture2D[(int)(PieceConstants.Id.Count - 1) * 2];
        // Load white pieces
        for (int pieceId = 0; pieceId < (int)PieceConstants.Id.Count - 1; pieceId++)
        {
            _pieceTextures[pieceId] = contentManager.Load<Texture2D>(TextureUtility.GetChessPieceTexturePath(
                Types.Color.White,
                PieceConstants.TextureName[pieceId + 1],
                _renderConfig.TextureResolution,
                _renderConfig.PieceShadows));
        }
        // Load black pieces
        for (int pieceId = 0; pieceId < (int)PieceConstants.Id.Count - 1; pieceId++)
        {
            _pieceTextures[pieceId + (int)PieceConstants.Id.Count - 1] = contentManager.Load<Texture2D>(TextureUtility.GetChessPieceTexturePath(
                Types.Color.Black,
                PieceConstants.TextureName[pieceId + 1],
                _renderConfig.TextureResolution,
                _renderConfig.PieceShadows));
        }
        // TODO: Load squares
    }

    public void DrawBoard(GraphicsDeviceManager graphicsDeviceManager)
    {
        _spriteBatch.Begin();
        
        // TODO: Draw board
        _spriteBatch.Draw(
            _pieceTextures[0],
            new Vector2(graphicsDeviceManager.PreferredBackBufferWidth / 2f, graphicsDeviceManager.PreferredBackBufferHeight / 2f),
            null,
            Color.White,
            0f,
            new Vector2(_pieceTextures[0].Width / 2f, _pieceTextures[0].Height / 2f),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        _spriteBatch.End();
    }
}