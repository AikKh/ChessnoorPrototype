namespace ChessnoorPrototype.ChessData;

public interface IValidator
{
    bool Validate(Board board, in Move move);
}
