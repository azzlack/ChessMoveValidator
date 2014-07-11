namespace ChessMoveValidator.Core.Interfaces.Factories
{
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Interface for chess board factories.
    /// </summary>
    public interface IBoardFactory
    {
        /// <summary>
        /// Creates a chess board from the specified FEN representation.
        /// </summary>
        /// <returns>The chess board.</returns>
        IBoard Create(Fen fen);
    }
}