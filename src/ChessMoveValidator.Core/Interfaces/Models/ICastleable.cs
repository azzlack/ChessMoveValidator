namespace ChessMoveValidator.Core.Interfaces.Models
{
    /// <summary>
    /// Interface for pieces that can be castled (i.e. Kings and Rooks).
    /// </summary>
    public interface ICastleable : IPiece
    {
        /// <summary>
        /// Gets or sets the zobrist hash keys for castling.
        /// </summary>
        /// <value>The zobrist hash keys for castling.</value>
        ulong[] ZobristHashKeysForCastling { get; set; } 
    }
}