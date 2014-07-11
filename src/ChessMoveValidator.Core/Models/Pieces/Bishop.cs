namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Represents a bishop.
    /// </summary>
    public class Bishop : Piece, IDiagonalMoveable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bishop" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Bishop(PieceColor color)
            : base(color)
        {
        }
    }
}