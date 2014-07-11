namespace ChessMoveValidator.Core.Interfaces.Models
{
    using ChessMoveValidator.Core.Enums;

    /// <summary>
    /// Interface for chess pieces.
    /// </summary>
    public interface IPiece
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <remarks>Should return a <a href="http://chessprogramming.wikispaces.com/Zobrist+Hashing">Zobrist hash key</a>.</remarks>
        /// <value>The key.</value>
        ulong Key { get; }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        PieceColor Color { get; }
    }
}