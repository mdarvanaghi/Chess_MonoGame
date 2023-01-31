using System;
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

    private const int PIECE_PADDING = 5;
    
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

    public void DrawBoard(Board board, GraphicsDeviceManager graphicsDeviceManager)
    {
        // 1. Figure out how big we can draw the chess board
        int smallestDimension = Math.Min(graphicsDeviceManager.PreferredBackBufferWidth,
            graphicsDeviceManager.PreferredBackBufferHeight);
        int squareResolution = (smallestDimension - (smallestDimension % 8)) / 8;
        
        float squareScaleFactor = (float) squareResolution / _renderConfig.TextureResolution; 
        float pieceScaleFactor = (float) squareResolution / (_renderConfig.TextureResolution + PIECE_PADDING);

        Vector2 midScreen = new(
            graphicsDeviceManager.PreferredBackBufferWidth / 2f,
            graphicsDeviceManager.PreferredBackBufferHeight / 2f);

        _spriteBatch.Begin();
        // 2. Draw squares
        Vector2 squareScale = Vector2.One * squareScaleFactor;
        // TODO: Draw squares
        
        // 3. Draw pieces
        Vector2 pieceScale = Vector2.One * pieceScaleFactor;

        for (int index = 0; index < 1; index++)
        {
            if (board.PieceIds[index] == 0) continue;
            
            int col = index % 8;
            int row = index / 8;
            
            // TODO: Invert since index 0 is a1 but position 0, 0 is top left
            Vector2 position = new(squareResolution * col, squareResolution * row);
            int pieceId = board.PieceIds[index];
            _spriteBatch.Draw(
                _pieceTextures[pieceId],
                position,
                null,
                Color.White,
                0f,
                new Vector2(_pieceTextures[pieceId].Width / 2f, _pieceTextures[pieceId].Height / 2f),
                pieceScale,
                SpriteEffects.None,
                0f
            );
        }

        // TODO: Calculate piece positions
        _spriteBatch.End();
    }
}