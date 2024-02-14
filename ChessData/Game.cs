namespace ChessnoorPrototype.ChessData;

public class Game
{
    private readonly Board _state = new();

    public Board State => _state;
}
