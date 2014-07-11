namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Represents a queen.
    /// </summary>
    public class Queen : Piece, IDiagonalMoveable, IStraightMoveable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Queen(PieceColor color) : base(color)
        {
        }
    }
}