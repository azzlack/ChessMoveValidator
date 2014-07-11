namespace ChessMoveValidator.BusinessLogic.Factories
{
    using System;

    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Factory for creating chess pieces.
    /// </summary>
    public class PieceFactory : IPieceFactory
    {
        /// <summary>
        /// The zobrist hash key generator
        /// </summary>
        private readonly IZobristHashKeyGenerator zobristHashKeyGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PieceFactory"/> class.
        /// </summary>
        /// <param name="zobristHashKeyGenerator">The zobrist hash key generator.</param>
        public PieceFactory(IZobristHashKeyGenerator zobristHashKeyGenerator)
        {
            this.zobristHashKeyGenerator = zobristHashKeyGenerator;
        }

        /// <summary>
        /// Creates a piece of the specified type and color.
        /// </summary>
        /// <typeparam name="T">The piece type</typeparam>
        /// <param name="color">The piece color.</param>
        /// <returns>A chess piece.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the piece type is not recognized.</exception>
        public T Create<T>(PieceColor color) where T : class, IPiece
        {
            if (typeof(T) == typeof(Pawn))
            {
                var pawn = new Pawn(color);
                this.zobristHashKeyGenerator.Generate(pawn);

                return pawn as T;
            }

            if (typeof(T) == typeof(Rook))
            {
                var rook = new Rook(color);
                this.zobristHashKeyGenerator.Generate(rook);

                return rook as T;
            }

            if (typeof(T) == typeof(Knight))
            {
                var knight = new Knight(color);
                this.zobristHashKeyGenerator.Generate(knight);

                return knight as T;
            }

            if (typeof(T) == typeof(Bishop))
            {
                var bishop = new Bishop(color);
                this.zobristHashKeyGenerator.Generate(bishop);

                return bishop as T;
            }

            if (typeof(T) == typeof(Queen))
            {
                var queen = new Queen(color);
                this.zobristHashKeyGenerator.Generate(queen);

                return queen as T;
            }

            if (typeof(T) == typeof(King))
            {
                var king = new King(color);
                this.zobristHashKeyGenerator.Generate(king);

                return king as T;
            }

            throw new ArgumentException(string.Format("Piece type '{0}' is not recognized", typeof(T).Name));
        }

        /// <summary>
        /// Creates a piece of the specified type and color.
        /// </summary>
        /// <param name="pieceType">The piece type.</param>
        /// <param name="color">The piece color.</param>
        /// <returns>A chess piece.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the piece type is not recognized.</exception>
        public IPiece Create(Type pieceType, PieceColor color)
        {
            if (pieceType == typeof(Pawn))
            {
                return this.Create<Pawn>(color);
            }

            if (pieceType == typeof(Rook))
            {
                return this.Create<Rook>(color);
            }

            if (pieceType == typeof(Knight))
            {
                return this.Create<Knight>(color);
            }

            if (pieceType == typeof(Bishop))
            {
                return this.Create<Bishop>(color);
            }

            if (pieceType == typeof(Queen))
            {
                return this.Create<Queen>(color);
            }

            if (pieceType == typeof(King))
            {
                return this.Create<King>(color);
            }

            throw new ArgumentException(string.Format("Piece type '{0}' is not recognized", pieceType.Name));
        }
    }
}