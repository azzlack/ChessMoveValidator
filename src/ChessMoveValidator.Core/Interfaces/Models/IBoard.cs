namespace ChessMoveValidator.Core.Interfaces.Models
{
    using System.Collections.Generic;

    using ChessMoveValidator.Core.Enums;

    /// <summary>
    /// Interface for chess boards.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Gets the board array.
        /// </summary>
        /// <value>The board array.</value>
        IPiece[] Array { get; }

        /// <summary>
        /// Gets the black pieces.
        /// </summary>
        /// <value>The black pieces.</value>
        IEnumerable<IPiece> BlackPieces { get; }

        /// <summary>
        /// Gets the white pieces.
        /// </summary>
        /// <value>The white pieces.</value>
        IEnumerable<IPiece> WhitePieces { get; }

        /// <summary>
        /// Gets the black king.
        /// </summary>
        /// <value>The black king.</value>
        ICheckable BlackKing { get; }

        /// <summary>
        /// Gets the white king.
        /// </summary>
        /// <value>The white king.</value>
        ICheckable WhiteKing { get; }

        /// <summary>
        /// Gets or sets the side to move.
        /// </summary>
        /// <value>The side to move.</value>
        PieceColor SideToMove { get; set; }

        /// <summary>
        /// Gets or sets the castling availability.
        /// </summary>
        /// <value>The castling availability.</value>
        CastlingAvailability CastlingAvailability { get; set; }

        /// <summary>
        /// Gets or sets the index of the en passant square.
        /// </summary>
        /// <value>The index of the en passant square.</value>
        int EnPassantSquareIndex { get; set; }

        /// <summary>
        /// Gets or sets a decimal number of half moves with respect to the 50 move draw rule.
        /// </summary>
        /// <remarks>It is reset to zero after a capture or a pawn move and incremented otherwise.</remarks>
        /// <value>The number of half moves.</value>
        int NumberOfHalfMoves { get; set; }

        /// <summary>
        /// Gets or sets the number of the full moves in the game.
        /// </summary>
        /// <remarks>It starts at 1, and is incremented after each Black's move.</remarks>
        /// <value>The number of moves.</value>
        int NumberOfRounds { get; set; }
    }
}