namespace ChessMoveValidator.Core.Interfaces.Factories
{
    using System;

    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Interface for creating chess pieces on the board.
    /// </summary>
    public interface IPieceFactory
    {
        /// <summary>
        /// Creates a piece of the specified type and color.
        /// </summary>
        /// <typeparam name="T">The piece type.</typeparam>
        /// <param name="color">The piece color.</param>
        /// <returns>A chess piece.</returns>
        T Create<T>(PieceColor color) where T : class, IPiece;

        /// <summary>
        /// Creates a piece of the specified type and color.
        /// </summary>
        /// <param name="pieceType">The piece type.</param>
        /// <param name="color">The piece color.</param>
        /// <returns>A chess piece.</returns>
        IPiece Create(Type pieceType, PieceColor color);
    }
}