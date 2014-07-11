namespace ChessMoveValidator.BusinessLogic.Factories
{
    using System.Linq;

    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Functions;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Factory for creating chess boards.
    /// </summary>
    public class BoardFactory : IBoardFactory
    {
        /// <summary>
        /// The hash key generator
        /// </summary>
        private readonly IZobristHashKeyGenerator hashKeyGenerator;

        /// <summary>
        /// The piece factory
        /// </summary>
        private readonly IPieceFactory pieceFactory;

        /// <summary>
        /// The board operations
        /// </summary>
        private readonly IBoardOperations boardOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardFactory" /> class.
        /// </summary>
        /// <param name="hashKeyGenerator">The hash key generator.</param>
        /// <param name="pieceFactory">The piece factory.</param>
        /// <param name="boardOperations">The board operations.</param>
        public BoardFactory(IZobristHashKeyGenerator hashKeyGenerator, IPieceFactory pieceFactory, IBoardOperations boardOperations)
        {
            this.hashKeyGenerator = hashKeyGenerator;
            this.pieceFactory = pieceFactory;
            this.boardOperations = boardOperations;
        }

        /// <summary>
        /// Creates a chess board from the specified FEN representation.
        /// </summary>
        /// <param name="fen">The FEN representation.</param>
        /// <returns>The chess board.</returns>
        public IBoard Create(Fen fen)
        {
            // 1. Create board and set side to move, half moves, round counter
            var b = new Board()
                        {
                            SideToMove = fen.SideToMove,
                            NumberOfHalfMoves = fen.HalfmoveClock,
                            NumberOfRounds = fen.FullmoveCounter
                        };

            // 2. Populate castling hash key array
            b.HashKeysForCastling = this.hashKeyGenerator.GenerateHashKeysForCastling();

            // 3. Populate en passant hash key array
            b.HashKeysForEnPassant = this.hashKeyGenerator.GenerateHashKeysForEnPassant();

            // 4. Set board squares
            foreach (var square in fen.Board.Where(x => x.Piece != null))
            {
                var p = this.pieceFactory.Create(square.Piece.GetType(), square.Piece.Color) as Piece;

                if (p != null) 
                { 
                    p.CurrentSquare = this.boardOperations.GetSquareIndex(square.File, square.Rank);

                    b.Array[p.CurrentSquare] = p;
                    b.CurrentHashKey ^= p.GetKey(p.CurrentSquare);
                }
            }

            // 5. Set castling availiability
            if (b.HashKeysForCastling != null)
            {
                b.CastlingAvailability = fen.CastlingRights;
                b.CurrentHashKey ^= b.HashKeysForCastling[(int)b.CastlingAvailability];
            }

            // 6. Set en passant status
            if (b.HashKeysForEnPassant != null && fen.EnPassantSquare != null)
            {
                b.EnPassantSquareIndex = this.boardOperations.GetSquareIndex(fen.EnPassantSquare.File, fen.EnPassantSquare.Rank);
                b.CurrentHashKey ^= b.HashKeysForEnPassant[fen.EnPassantSquare.File];
            }

            return b;
        }
    }
}