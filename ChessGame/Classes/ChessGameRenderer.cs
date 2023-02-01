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

        _pieceTextures = new Texture2D[(int)(PieceConstants.Id.Count) * 2];
        // Load white pieces
        for (int pieceId = 1; pieceId < (int)PieceConstants.Id.Count; pieceId++)
        {
            _pieceTextures[pieceId] = contentManager.Load<Texture2D>(TextureUtility.GetChessPieceTexturePath(
                Types.Color.White,
                PieceConstants.TextureName[pieceId],
                _renderConfig.TextureResolution,
                _renderConfig.PieceShadows));
        }
        // Load black pieces
        for (int pieceId = 1; pieceId < (int)PieceConstants.Id.Count; pieceId++)
        {
            _pieceTextures[pieceId + (int)PieceConstants.Id.Count] = contentManager.Load<Texture2D>(TextureUtility.GetChessPieceTexturePath(
                Types.Color.Black,
                PieceConstants.TextureName[pieceId],
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
        float pieceScaleFactor = (float) squareResolution / (_renderConfig.TextureResolution);

        Vector2 midScreen = new(
            graphicsDeviceManager.PreferredBackBufferWidth / 2f,
            graphicsDeviceManager.PreferredBackBufferHeight / 2f);

        _spriteBatch.Begin();
        // 2. Draw squares
        Vector2 squareScale = Vector2.One * squareScaleFactor;
        // TODO: Draw squares
        
        // 3. Draw pieces
        Vector2 pieceScale = Vector2.One * pieceScaleFactor;

        float scaledHalf = (_renderConfig.TextureResolution / 2) * pieceScaleFactor;

        for (int index = 0; index < board.Pieces.Length; index++)
        {
            if (board.Pieces[index].PieceId == 0) continue;
            
            int col = index % 8;
            int row = 8 - index / 8;

            int offset = board.Pieces[index].Color == Types.Color.Black ? _pieceTextures.Length / 2 : 0;
            // TODO: Invert row since index 0 is a1 but position 0, 0 is top left
            
            Vector2 position = new(squareResolution * col + scaledHalf, squareResolution * row - scaledHalf);
            int pieceId = (int)board.Pieces[index].PieceId;
            _spriteBatch.Draw(
                _pieceTextures[pieceId + offset],
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