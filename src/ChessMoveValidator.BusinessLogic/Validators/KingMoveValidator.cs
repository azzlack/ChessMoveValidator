namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="King"/> piece.
    /// </summary>
    public class KingMoveValidator : IMoveValidator<King>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(King piece, Move move)
        {
            // Move right diagonal forward
            if ((move.EndSquare.File == move.StartSquare.File + 1) && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
            {
                return true;
            }

            // Move left diagonal backward
            if ((move.EndSquare.File == move.StartSquare.File - 1) && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
            {
                return true;
            }

            // Move left diagonal forward
            if ((move.EndSquare.File == move.StartSquare.File - 1) && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
            {
                return true;
            }

            // Move right diagonal backward
            if ((move.EndSquare.File == move.StartSquare.File + 1) && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
            {
                return true;
            }

            // Move right
            if ((move.EndSquare.File == move.StartSquare.File + 1) && (move.EndSquare.Rank == move.StartSquare.Rank))
            {
                return true;
            }

            // Move straight forward
            if ((move.EndSquare.File == move.StartSquare.File) && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
            {
                return true;
            }

            // Move left
            if ((move.EndSquare.File == move.StartSquare.File - 1) && (move.EndSquare.Rank == move.StartSquare.Rank))
            {
                return true;
            }

            // Move straight backward
            if ((move.EndSquare.File == move.StartSquare.File) && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
            {
                return true;
            }

            return false;
        }
    }
}