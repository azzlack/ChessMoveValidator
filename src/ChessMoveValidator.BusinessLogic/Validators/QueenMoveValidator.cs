namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="Queen"/> piece.
    /// </summary>
    public class QueenMoveValidator : IMoveValidator<Queen>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(Queen piece, Move move)
        {
            if (move.StartSquare.File - move.EndSquare.File == move.StartSquare.Rank - move.EndSquare.Rank)
            {
                return true;
            }

            if (move.StartSquare.File - move.EndSquare.File == -(move.StartSquare.Rank - move.EndSquare.Rank))
            {
                return true;
            }

            if (move.EndSquare.File == move.StartSquare.File)
            {
                return true;
            }

            if (move.EndSquare.Rank == move.StartSquare.Rank)
            {
                return true;
            }

            return false;
        }
    }
}