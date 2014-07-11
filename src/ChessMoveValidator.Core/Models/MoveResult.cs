namespace ChessMoveValidator.Core.Models
{
    /// <summary>
    /// Represents the result of a move on the chess board.
    /// </summary>
    public class MoveResult
    {
        /// <summary>
        /// Gets or sets the move.
        /// </summary>
        /// <value>The move.</value>
        public Move Move { get; set; }

        /// <summary>
        /// Gets or sets the captured piece.
        /// </summary>
        /// <value>The captured piece.</value>
        public Piece CapturedPiece { get; set; }
    }
}