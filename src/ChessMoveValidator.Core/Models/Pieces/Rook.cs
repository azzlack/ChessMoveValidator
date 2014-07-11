namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Represents a rook.
    /// </summary>
    public class Rook : Piece, ICastleable, IStraightMoveable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rook" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Rook(PieceColor color)
            : base(color)
        {
        }

        /// <summary>
        /// Gets or sets the zobrist hash keys for castling.
        /// </summary>
        /// <value>The zobrist hash keys for castling.</value>
        public ulong[] ZobristHashKeysForCastling { get; set; }
    }
}