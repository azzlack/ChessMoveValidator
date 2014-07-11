namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="Bishop"/> piece.
    /// </summary>
    public class BishopMoveValidator : IMoveValidator<Bishop>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(Bishop piece, Move move)
        {
            if (move.StartSquare.File - move.EndSquare.File == move.StartSquare.Rank - move.EndSquare.Rank)
            {
                return true;
            }

            if (move.StartSquare.File - move.EndSquare.File == -(move.StartSquare.Rank - move.EndSquare.Rank))
            {
                return true;
            }

            return false;
        }
    }
}