namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="Knight"/> piece.
    /// </summary>
    public class KnightMoveValidator : IMoveValidator<Knight>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(Knight piece, Move move)
        {
            if ((move.EndSquare.File == move.StartSquare.File + 1) && (move.EndSquare.Rank == move.StartSquare.Rank + 2))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File - 1) && (move.EndSquare.Rank == move.StartSquare.Rank + 2))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File - 1) && (move.EndSquare.Rank == move.StartSquare.Rank - 2))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File + 1) && (move.EndSquare.Rank == move.StartSquare.Rank - 2))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File + 2) && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File + 2) && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File - 2) && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
            {
                return true;
            }

            if ((move.EndSquare.File == move.StartSquare.File - 2) && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
            {
                return true;
            }

            return false;
        }
    }
}