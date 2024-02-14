using System.Drawing;

namespace ChessnoorPrototype.ChessData;

public class Board
{
    public const int Size = 8;

    private readonly Piece?[,] _board;

    public Board()
    {
        _board = new Piece?[Size, Size];
        InitBoard(_board);
    }

    public Piece? this[int x, int y] =>
        _board[y, x];

    public Piece? this[Point point]
    {
        get => _board[point.Y, point.X];

        private set => _board[point.Y, point.X] = value;
    }

    public void ExecuteMove(in Move move)
    {
        if (this[move.StartPoint] is Piece start)
        {
            this[move.EndPoint] = start;
            this[move.StartPoint] = null;
            return;
        }
        throw new Exception("invalid move!");
    }

    public static void InitBoard(Piece?[,] board)
    {
        // Rooks
        board[0, 0] = new Piece(PieceType.B_Rook);
        board[0, 7] = new Piece(PieceType.B_Rook);

        board[7, 0] = new Piece(PieceType.W_Rook);
        board[7, 7] = new Piece(PieceType.W_Rook);

        // Knight
        board[0, 1] = new Piece(PieceType.B_Knight);
        board[0, 6] = new Piece(PieceType.B_Knight);

        board[7, 1] = new Piece(PieceType.W_Knight);
        board[7, 6] = new Piece(PieceType.W_Knight);

        // Bishops
        board[0, 2] = new Piece(PieceType.B_Bishop);
        board[0, 5] = new Piece(PieceType.B_Bishop);

        board[7, 2] = new Piece(PieceType.W_Bishop);
        board[7, 5] = new Piece(PieceType.W_Bishop);

        // Queens
        board[0, 3] = new Piece(PieceType.B_Queen);
        board[7, 3] = new Piece(PieceType.W_Queen);

        // Kings
        board[0, 4] = new Piece(PieceType.B_King);
        board[7, 4] = new Piece(PieceType.W_King);

        // Pawns
        for (int i = 0; i < Size; i++)
        {
            board[1, i] = new Piece(PieceType.B_Pawn);
            board[6, i] = new Piece(PieceType.W_Pawn);
        }
    }
}
