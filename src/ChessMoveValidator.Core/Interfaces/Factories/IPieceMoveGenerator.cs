namespace ChessMoveValidator.Core.Interfaces.Factories
{
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Interface for chess piece move generators
    /// </summary>
    public interface IPieceMoveGenerator<T> where T : IPiece
    {
        /// <summary>
        /// Generates pseudo-legal moves for the specified piece on the board. 
        /// </summary>
        /// <remarks>Does not check if the king would be in check if move is completed.</remarks>
        /// <param name="board">The board.</param>
        /// <param name="piece">The piece.</param>
        /// <param name="start">The start.</param>
        /// <param name="moves">The moves.</param>
        /// <returns>System.Int32.</returns>
        int GeneratePseudoLegalMoves(IBoard board, T piece, int start, int[] moves);
    }
}