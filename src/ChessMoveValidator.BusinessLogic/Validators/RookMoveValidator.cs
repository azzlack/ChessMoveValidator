namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="Rook"/> piece.
    /// </summary>
    public class RookMoveValidator : IMoveValidator<Rook>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(Rook piece, Move move)
        {
            // Check if file is the same
            if (move.StartSquare.File != move.EndSquare.File)
            {
                return false;
            }

            // Check if rank is the same
            if (move.StartSquare.Rank != move.EndSquare.Rank)
            {
                return false;
            }

            return true;
        }
    }
}