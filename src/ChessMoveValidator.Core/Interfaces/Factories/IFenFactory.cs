namespace ChessMoveValidator.Core.Interfaces.Factories
{
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Interface for creating Forsyth–Edwards Notation (FEN) objects.
    /// </summary>
    public interface IFenFactory
    {
        /// <summary>
        /// Creates a FEN representation with default positions.
        /// </summary>
        /// <returns>A FEN representation.</returns>
        Fen Create();

        /// <summary>
        /// Creates a FEN representation from the specified string.
        /// </summary>
        /// <param name="fenPosition">The FEN strings.</param>
        /// <returns>A FEN representation.</returns>
        Fen Create(string fenPosition);
    }
}