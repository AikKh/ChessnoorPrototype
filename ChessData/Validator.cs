using System.Drawing;

namespace ChessnoorPrototype.ChessData;

public class BasicValidator : IValidator
{
    public bool Validate(Board board, in Move move)
    {
        if (move.StartPoint == move.EndPoint)
            return false;

        if (board[move.StartPoint] is Piece start)
        {
            if (board[move.EndPoint] is Piece end)
            {
                return !start.SameColor(end);
            }
            return true;
        }
        return false;
    }
}
