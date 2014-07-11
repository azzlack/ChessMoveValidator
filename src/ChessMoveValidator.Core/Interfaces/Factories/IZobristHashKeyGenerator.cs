namespace ChessMoveValidator.Core.Interfaces.Factories
{
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Interface for generating Zobrist hash keys.
    /// </summary>
    public interface IZobristHashKeyGenerator
    {
        /// <summary>
        /// Generates the <a href="http://chessprogramming.wikispaces.com/Zobrist+Hashing">Zobrist Hash Key</a> for the specified piece.
        /// </summary>
        /// <param name="piece">The piece.</param>
        void Generate(Piece piece);

        /// <summary>
        /// Generates hash keys for en passant moves.
        /// </summary>
        /// <returns>A list of hash keys for en passant moves.</returns>
        ulong[] GenerateHashKeysForEnPassant();

        /// <summary>
        /// Generates hash keys for castling moves.
        /// </summary>
        /// <returns>A list of hash keys for castling moves.</returns>
        ulong[] GenerateHashKeysForCastling();
    }
}