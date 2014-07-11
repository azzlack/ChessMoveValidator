namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;

    /// <summary>
    /// Represents a pawn.
    /// </summary>
    public class Pawn : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Pawn(PieceColor color)
            : base(color)
        {
        }
    }
}