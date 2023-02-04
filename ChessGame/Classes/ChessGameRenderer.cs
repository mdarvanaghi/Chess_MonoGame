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
        public Color LightSquareColor;
        public Color DarkSquareColor;

        public ChessGameRenderConfig(
            GraphicsDevice graphicsDevice,
            int textureResolution,
            bool pieceShadows, 
            Color lightSquareColor, 
            Color darkSquareColor)
        {
            GraphicsDevice = graphicsDevice;
            TextureResolution = textureResolution;
            PieceShadows = pieceShadows;
            LightSquareColor = lightSquareColor;
            DarkSquareColor = darkSquareColor;
        }
    }
    
    private Texture2D[] _pieceTextures;
    private SpriteBatch _spriteBatch;
    private ChessGameRenderConfig _renderConfig;
    private Texture2D _squareTexture;
    private Rectangle _squareRectangle;
    private Vector2 _textureOrigin;

    private const int PIECE_PADDING = 5;
    
    public ChessGameRenderer(ChessGameRenderConfig renderConfig)
    {
        _renderConfig = renderConfig;
        _textureOrigin = new Vector2(_renderConfig.TextureResolution / 2f, _renderConfig.TextureResolution / 2f);
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
        // Create white 1x1 pixel texture for drawing squares
        _squareTexture = new Texture2D(_renderConfig.GraphicsDevice, 1, 1);
        _squareTexture.SetData(new[] {Color.White});
        _squareRectangle = new Rectangle(0, 0, _renderConfig.TextureResolution, _renderConfig.TextureResolution);
    }

    public void UnloadTextures()
    {
        _spriteBatch.Dispose();
        _squareTexture.Dispose();
    }

    public void DrawBoard(Board board, GraphicsDeviceManager graphicsDeviceManager)
    {
        // 1. Figure out how big we can draw the chess board
        int smallestDimension = Math.Min(_renderConfig.GraphicsDevice.Viewport.Width,
            _renderConfig.GraphicsDevice.Viewport.Height);
        int squareResolution = (smallestDimension - (smallestDimension % 8)) / 8;
        
        float squareScaleFactor = (float) squareResolution / _renderConfig.TextureResolution; 
        float pieceScaleFactor = (float) squareResolution / _renderConfig.TextureResolution;

        Vector2 squareScale = Vector2.One * squareScaleFactor;
        Vector2 pieceScale = Vector2.One * pieceScaleFactor;
        float scaledHalf = (_renderConfig.TextureResolution / 2) * pieceScaleFactor;
        
        _spriteBatch.Begin();
        for (int index = 0; index < board.Pieces.Length; index++)
        {
            int col = index % 8;
            int row = 8 - index / 8;
            Vector2 position = new(squareResolution * col + scaledHalf, squareResolution * row - scaledHalf);
            
            // 1. Draw square
            _spriteBatch.Draw(
                _squareTexture,
                position,
                _squareRectangle,
                (index + row) % 2 == 0 ? _renderConfig.DarkSquareColor : _renderConfig.LightSquareColor,
                0f,
                _textureOrigin,
                squareScale,
                SpriteEffects.None,
                0f
            );

            // 2. Draw piece
            if (board.Pieces[index].PieceId == 0) continue;
            
            // Add offset if black to get the right texture
            int pieceColorOffset = board.Pieces[index].Color == Types.Color.Black ? _pieceTextures.Length / 2 : 0;
            int pieceId = (int)board.Pieces[index].PieceId;
            _spriteBatch.Draw(
                _pieceTextures[pieceId + pieceColorOffset],
                position,
                null,
                Color.White,
                0f,
                _textureOrigin,
                pieceScale,
                SpriteEffects.None,
                0f
            );
        }
        _spriteBatch.End();
    }
}