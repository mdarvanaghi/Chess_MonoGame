namespace ChessGame.Classes;

public struct Square
{
    public int X, Y;

    public new string ToString()
    {
        char x = (char) (X + 97);
        char y = (char) (Y + 49);
        return $"{x}{y}";
    }
}