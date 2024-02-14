namespace ChessnoorPrototype.ChessData;

public enum PieceType
{
    W_King,
    W_Queen,
    W_Rook,
    W_Bishop,
    W_Knight,
    W_Pawn,

    B_King,
    B_Queen,
    B_Rook,
    B_Bishop,
    B_Knight,
    B_Pawn
}

public readonly struct Piece(PieceType type)
{
    public PieceType Type { get; init; } = type;
    public string ImagePath => PathMapper[Type];

    public bool SameColor(Piece other)
    {
        bool isThisWhite = (int)Type <= 5;
        bool isOtherWhite = (int)other.Type <= 5;

        return isThisWhite == isOtherWhite;
    }

    private static readonly Dictionary<PieceType, string> PathMapper = new()
    {
        [PieceType.W_King]   = "Chess_klt45.svg",
        [PieceType.W_Queen]  = "Chess_qll45.svg",
        [PieceType.W_Rook]   = "Chess_rlt45.svg",
        [PieceType.W_Bishop] = "Chess_blt45.svg",
        [PieceType.W_Knight] = "Chess_nlt45.svg",
        [PieceType.W_Pawn]   = "Chess_plt45.svg",

        [PieceType.B_King]   = "Chess_kdt45.svg",
        [PieceType.B_Queen]  = "Chess_qdl45.svg",
        [PieceType.B_Rook]   = "Chess_rdt45.svg",
        [PieceType.B_Bishop] = "Chess_bdt45.svg",
        [PieceType.B_Knight] = "Chess_ndt45.svg",
        [PieceType.B_Pawn]   = "Chess_pdt45.svg",
    };
}
