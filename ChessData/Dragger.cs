using System.Drawing;

namespace ChessnoorPrototype.ChessData;

public class Dragger(IValidator validator)
{
    private readonly IValidator _validator = validator;

    private bool _ready = false;

    private Point _start, _end;

    public bool Selected { get; set; } = false;

    public Point SelectedPoint => _start;

    public void AddPosition(Board board, Point point)
    {
        if (!Selected && board[point] is null)
            return;

        if (Selected)
        {
            _ready = true;

            _end = point;
            Selected = false;
            return;
        }
        _start = point;
        Selected = true;
    }

    public void AddPosition(Board board, int x, int y)
    {
        AddPosition(board, new Point(x, y));
    }

    public bool MoveIsReady(Board board, out Move move)
    {
        move = new() { StartPoint = _start, EndPoint = _end };
        
        if (_ready)
        {
            _ready = false;
            return _validator.Validate(board, move);
        }

        return false;
    }
}
