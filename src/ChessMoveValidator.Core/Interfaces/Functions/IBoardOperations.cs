namespace ChessMoveValidator.Core.Interfaces.Functions
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Interface for chess board operations
    /// </summary>
    public interface IBoardOperations
    {
        /// <summary>
        /// Determines whether [the specified squareIndex index] [is a valid squareIndex].
        /// </summary>
        /// <param name="squareIndex">The squareIndex.</param>
        /// <returns><c>true</c> if [the specified squareIndex index] [is a valid squareIndex]; otherwise, <c>false</c>.</returns>
        bool IsSquareValid(int squareIndex);

        /// <summary>
        /// Gets the file for the squareIndex at the specified index.
        /// </summary>
        /// <param name="squareIndex">The squareIndex index.</param>
        /// <returns>The file.</returns>
        int GetFile(int squareIndex);

        /// <summary>
        /// Gets the rank for the squareIndex at the specified index.
        /// </summary>
        /// <param name="squareIndex">The squareIndex index.</param>
        /// <returns>The rank.</returns>
        int GetRank(int squareIndex);

        /// <summary>
        /// Gets the index of the squareIndex in the <c>Array</c> at the specified file and rank.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="rank">The rank.</param>
        /// <returns>The squareIndex index.</returns>
        int GetSquareIndex(int file, int rank);

        /// <summary>
        /// Gets the index of the squareIndex in the <c>Array</c> that represents the capture move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="moving">The moving piece.</param>
        /// <param name="captured">The captured piece.</param>
        /// <returns>The squareIndex index.</returns>
        int GetSquareIndexForCapture(IBoard board, IPiece moving, IPiece captured);

        /// <summary>
        /// Gets the squareIndex index for promotion merge.
        /// </summary>
        /// <param name="promotion">The promotion.</param>
        /// <returns>System.Int32.</returns>
        int GetSquareIndexForPromotionMerge(Promotion promotion);

        /// <summary>
        /// Gets the squareIndex index for the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>The squareIndex index.</returns>
        int GetSquareIndexForMove(int start, int end);
    }
}