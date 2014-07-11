namespace ChessMoveValidator.Core.Interfaces.Functions
{
    using System;
    using System.Collections.Generic;

    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Interface for move operations.
    /// </summary>
    public interface IMoveOperations
    {
        /// <summary>
        /// Analyzes the specified FEN representations, and returns the move.
        /// </summary>
        /// <param name="baseFen">The base FEN.</param>
        /// <param name="newFen">The new FEN.</param>
        /// <returns>The move result.</returns>
        [Obsolete]
        MoveResult GetMove(Fen baseFen, Fen newFen);

        /// <summary>
        /// Analyzes the specified boards, and returns the moves that has occured between <paramref name="firstBoard"/> and <paramref name="secondBoard"/>.
        /// </summary>
        /// <param name="firstBoard">The first board.</param>
        /// <param name="secondBoard">The second board.</param>
        /// <returns>The moves.</returns>
        IEnumerable<Move> ParseMoves(IBoard firstBoard, IBoard secondBoard);

        /// <summary>
        /// Tries to perform the specified move on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="move">The move representation.</param>
        void Move(IBoard board, Move move);

        /// <summary>
        /// Tries to perform the specified move on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="algebraicMove">The algebraic move notation.</param>
        void Move(IBoard board, string algebraicMove);
    }
}