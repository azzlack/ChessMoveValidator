namespace ChessMoveValidator.BusinessLogic.Validators
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Validators;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move validator for the <see cref="Pawn"/> piece.
    /// </summary>
    public class PawnMoveValidator : IMoveValidator<Pawn>
    {
        /// <summary>
        /// Validates the specified piece move.
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="move">The move.</param>
        /// <returns><c>true</c> if move is valid. Otherwise <c>false</c>.</returns>
        public bool Validate(Pawn piece, Move move)
        {
            // White pawn rules
            if (piece.Color == PieceColor.White)
            {
                // Check if this is a capture move
                if (move.EndSquare.Piece != null)
                {
                    // One square straight forward
                    if ((move.EndSquare.File == move.StartSquare.File)
                        && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
                    {
                        return true;
                    }

                    // Two squares straight forward (only allowed from pawn start position)
                    if (move.StartSquare.Rank == 1 && (move.EndSquare.File == move.StartSquare.File)
                        && (move.EndSquare.Rank == move.StartSquare.Rank + 2))
                    {
                        return true;
                    }
                }
                else
                {
                    // Move right diagonal forward
                    if ((move.EndSquare.File == move.StartSquare.File + 1)
                        && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
                    {
                        return true;
                    }

                    // Move left diagonal forward
                    if ((move.EndSquare.File == move.StartSquare.File - 1)
                        && (move.EndSquare.Rank == move.StartSquare.Rank + 1))
                    {
                        return true;
                    }
                }
            }
            else
            {
                // Check if this is a capture move
                if (move.EndSquare.Piece != null)
                {
                    // One square straight forward
                    if ((move.EndSquare.File == move.StartSquare.File)
                        && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
                    {
                        return true;
                    }

                    // Two squares straight forward (only allowed from pawn start position)
                    if (move.StartSquare.Rank == 6 && (move.EndSquare.File == move.StartSquare.File)
                        && (move.EndSquare.Rank == move.StartSquare.Rank - 2))
                    {
                        return true;
                    }
                }
                else
                {
                    // Move right diagonal forward
                    if ((move.EndSquare.File == move.StartSquare.File + 1)
                        && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
                    {
                        return true;
                    }

                    // Move left diagonal forward
                    if ((move.EndSquare.File == move.StartSquare.File - 1)
                        && (move.EndSquare.Rank == move.StartSquare.Rank - 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}