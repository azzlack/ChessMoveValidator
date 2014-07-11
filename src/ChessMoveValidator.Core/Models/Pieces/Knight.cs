namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;

    /// <summary>
    /// Represents a knight.
    /// </summary>
    public class Knight : Piece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public Knight(PieceColor color)
            : base(color)
        {
        }
    }
}