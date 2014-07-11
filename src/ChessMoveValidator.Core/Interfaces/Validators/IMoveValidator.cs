namespace ChessMoveValidator.Core.Interfaces.Validators
{
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Interface for piece move validators.
    /// </summary>
    /// <typeparam name="T">The piece type.</typeparam>
    public interface IMoveValidator<in T> where T : Piece
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        bool Validate(T piece, Move move);
    }
}