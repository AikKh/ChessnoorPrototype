using System.Drawing;

namespace ChessnoorPrototype.ChessData;

public readonly struct Move
{
    public Point StartPoint { get; init; }
    public Point EndPoint { get; init; }
}
