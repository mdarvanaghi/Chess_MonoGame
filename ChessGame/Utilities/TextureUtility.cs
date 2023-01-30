using System.IO;
using System.Text;

namespace ChessGame.Utilities;

public static class TextureUtility
{
    private const string WITH_SHADOW_DIR = "Textures/Chess/PNGs/With_Shadow";
    private const string NO_SHADOW_DIR = "Textures/Chess/PNGs/No_Shadow";
    
    public class Theme
    {
        private const string BROWN = "brown";
        private const string GRAY = "gray";
    }
    
    public static string GetChessPieceTexturePath(Types.Color color, string piece, int resolution, bool shadow)
    {
        StringBuilder filename = new();
        filename
            .Append(color == Types.Color.White ? 'w' : 'b')
            .Append('_')
            .Append(piece)
            .Append('_')
            .Append("png")
            .Append(shadow ? $"_shadow" : "")
            .Append('_')
            .Append(resolution)
            .Append("px");
        string root = Path.Combine(
            shadow ? WITH_SHADOW_DIR : NO_SHADOW_DIR, 
            shadow ? $"{resolution}px" : $"{resolution}h");
        return Path.Combine(root, filename.ToString());
    }

    public static string GetBoardSquareTexturePath(Types.Color color, string theme)
    {
        StringBuilder path = new();
        // path
        //     .Append(color == Types.Color.White ? 'w' : 'b')
        //     .Append('_')
        //     .Append(piece)
        //     .Append('_')
        //     .Append("png")
        //     .Append(resolution)
        //     .Append("px");
        return path.ToString();
    }
}