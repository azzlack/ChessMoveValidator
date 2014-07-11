namespace ChessMoveValidator.BusinessLogic.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Functions;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    public class MoveOperations : IMoveOperations
    {
        /// <summary>
        /// The board operations
        /// </summary>
        private readonly IBoardOperations boardOperations;

        /// <summary>
        /// The pawn move generator
        /// </summary>
        private readonly IPieceMoveGenerator<Pawn> pawnMoveGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveOperations" /> class.
        /// </summary>
        /// <param name="boardOperations">The board operations.</param>
        /// <param name="pawnMoveGenerator">The pawn move generator.</param>
        public MoveOperations(IBoardOperations boardOperations, IPieceMoveGenerator<Pawn> pawnMoveGenerator)
        {
            this.boardOperations = boardOperations;
            this.pawnMoveGenerator = pawnMoveGenerator;
        }

        [Obsolete]
        public MoveResult GetMove(Fen baseFen, Fen newFen)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Analyzes the specified boards, and returns the moves that has occured between <paramref name="firstBoard" /> and <paramref name="secondBoard" />.
        /// </summary>
        /// <param name="firstBoard">The first board.</param>
        /// <param name="secondBoard">The second board.</param>
        /// <returns>The moves.</returns>
        /// <exception cref="System.ArgumentException">Thrown if no moves could be found</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Maximum number of moves between boards is 2</exception>
        public IEnumerable<Move> ParseMoves(IBoard firstBoard, IBoard secondBoard)
        {
            var moves = new List<Move>();

            // Only look in squares that now has a piece
            for (var i = 0; i < secondBoard.Array.Length; i++)
            {
                if (secondBoard.Array[i] != null)
                {
                    var newPiece = secondBoard.Array[i];
                    var basePiece = firstBoard.Array[i];

                    // Skip processing if this piece is in the same position on both boards
                    if (basePiece != null && basePiece.Key == newPiece.Key)
                    {
                        continue;
                    }

                    // Find the base piece that was moved to this square
                    // That piece must have been located on one the squares that are now empty
                    for (var j = 0; j < firstBoard.Array.Length; j++)
                    {
                        // Find the square in the base board with the same rank and file as the new empty squares, but has a piece
                        if (firstBoard.Array[j] != null && secondBoard.Array[j] == null && firstBoard.Array[j].GetType() == newPiece.GetType())
                        {
                            var move = new Move()
                                           {
                                               StartSquare = new Square(this.boardOperations.GetRank(j), this.boardOperations.GetFile(j)),
                                               EndSquare = new Square(this.boardOperations.GetRank(i), this.boardOperations.GetFile(i))
                                           };

                            moves.Add(move);
                        }
                    }
                }
            }

            // There must be a difference of at least one move between the boards
            if (!moves.Any())
            {
                throw new ArgumentException("No moves could be found");
            }

            // Castling will be parsed as two moves, but everything above that can not be parsed reliably
            if (moves.Count > 2)
            {
                throw new ArgumentOutOfRangeException("Maximum number of moves between boards is 2");
            }

            return moves;
        }

        /// <summary>
        /// Tries to perform the specified move on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="move">The move representation.</param>
        /// <exception cref="System.Exception">Thrown if the move is invalid</exception>
        public void Move(IBoard board, Move move)
        {
            // 1. Set check and pin status
            this.SetCheckAndPinStatus(board);

            // 2. Generate possible moves
            var moves = this.GetPossibleMoves(board, 0);

            // 3. Check if move is in list of possible moves, and perform move if it is valid
            for (var i = 0; i < moves.Length; ++i)
            {
                //if (moves[i]) == decoded)
                //{
                    // Perform move
                    //return;
                //}
            }

            throw new Exception("Invalid move:" + move);
        }

        public void Move(IBoard board, string algebraicMove)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the check and ping status for the pieces on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        private void SetCheckAndPinStatus(IBoard board)
        {
            King k;

            // Check if king can castle
            if (board.SideToMove == PieceColor.Black)
            {
                k = board.BlackKing as King;

                // Reset pin status
                foreach (Piece p in board.BlackPieces)
                {
                    p.PinStatus = PinStatus.None;
                }

                if (k.CurrentSquare == SquareIndex.E8)
                {
                    k.CanCastleKingSide = board.Array[SquareIndex.F8] == null && board.Array[SquareIndex.G8] == null;
                    k.CanCastleQueenSide = board.Array[SquareIndex.B8] == null && board.Array[SquareIndex.C8] == null && board.Array[SquareIndex.D8] == null;
                }
            }
            else
            {
                k = board.WhiteKing as King;

                // Reset pin status
                foreach (Piece p in board.WhitePieces)
                {
                    p.PinStatus = PinStatus.None;
                }

                if (k.CurrentSquare == SquareIndex.E1)
                {
                    k.CanCastleKingSide = board.Array[SquareIndex.F1] == null && board.Array[SquareIndex.G1] == null;
                    k.CanCastleQueenSide = board.Array[SquareIndex.B1] == null && board.Array[SquareIndex.C1] == null && board.Array[SquareIndex.D1] == null;
                }
            }

            // Reset king check status
            k.NumberOfCheckingPieces = 0;
            k.Checker = null;

            // Set starting point for king check and pin calculation
            var startSquare = k.CurrentSquare;

            // Check if king is pinned/checked from any direction
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.N, k, PinStatus.NS);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.S, k, PinStatus.NS);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.W, k, PinStatus.WE);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.E, k, PinStatus.WE);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.NE, k, PinStatus.SWNE);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.SW, k, PinStatus.SWNE);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.NW, k, PinStatus.NWSE);
            this.SetKingCheckedPinnedStatus(board, startSquare, SquareDirection.SE, k, PinStatus.NWSE);

            // Check if king is in check by a knight
            var knightSquares = new[] { 18, 33, 31, 14, -18, -33, -31, -14 };

            foreach (var i in knightSquares)
            {
                if (((i + startSquare) & 0x88) == 0)
                {
                    if (board.Array[i + startSquare] != null && board.Array[i + startSquare].Color != board.SideToMove && board.Array[i + startSquare] is Knight)
                    {
                        k.NumberOfCheckingPieces++;
                        k.Checker = board.Array[i + startSquare];

                        return;
                    }
                }
            }

            // Check if king is in check by a pawn
            if (board.SideToMove == PieceColor.White)
            {
                if (this.boardOperations.IsSquareValid(startSquare + SquareDirection.NE))
                {
                    if (board.Array[startSquare + SquareDirection.NE] != null && board.Array[startSquare + SquareDirection.NE].Color != board.SideToMove && board.Array[startSquare + SquareDirection.NE] is Pawn)
                    {
                        k.NumberOfCheckingPieces++;
                        k.Checker = board.Array[startSquare + SquareDirection.NE];
                    }
                }
                else if (this.boardOperations.IsSquareValid(startSquare + SquareDirection.NW))
                {
                    if (board.Array[startSquare + SquareDirection.NW] != null && board.Array[startSquare + SquareDirection.NW].Color != board.SideToMove && board.Array[startSquare + SquareDirection.NW] is Pawn)
                    {
                        k.NumberOfCheckingPieces++;
                        k.Checker = board.Array[startSquare + SquareDirection.NW];
                    }
                }
            }
            else
            {
                if (this.boardOperations.IsSquareValid(startSquare + SquareDirection.SE))
                {
                    if (board.Array[startSquare + SquareDirection.SE] != null && board.Array[startSquare + SquareDirection.SE].Color != board.SideToMove && board.Array[startSquare + SquareDirection.SE] is Pawn)
                    {
                        k.NumberOfCheckingPieces++;
                        k.Checker = board.Array[startSquare + SquareDirection.SE];
                    }
                }
                else if (this.boardOperations.IsSquareValid(startSquare + SquareDirection.SW))
                {
                    if (board.Array[startSquare + SquareDirection.SW] != null && board.Array[startSquare + SquareDirection.SW].Color != board.SideToMove && board.Array[startSquare + SquareDirection.SW] is Pawn)
                    {
                        k.NumberOfCheckingPieces++;
                        k.Checker = board.Array[startSquare + SquareDirection.SW];
                    }
                }
            }
        }

        /// <summary>
        /// Sets the king checked/pinned status.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="startSquareIndex">The starting square index.</param>
        /// <param name="dir">The direction.</param>
        /// <param name="k">The king.</param>
        /// <param name="pin">The pin status.</param>
        private void SetKingCheckedPinnedStatus(IBoard board, int startSquareIndex, int dir, King k, PinStatus pin)
        {
            var checkRay = new int[7];
            var checkP = 0;

            IPiece potentialPinned = null;

            // Check sqaures in direct contact with the start square
            for (var i = startSquareIndex + dir; (i & 0x88) == 0; i += dir)
            {
                checkRay[checkP++] = i;

                if (board.Array[i] != null)
                {
                    // Check if the piece is friendly (same color)
                    if (board.Array[i].Color == k.Color)
                    {
                        if (potentialPinned == null)
                        {
                            // The piece is shielding the king from attacks from this direction
                            potentialPinned = board.Array[i];
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        // Check if there is a shielding friendly piece
                        if (potentialPinned == null)
                        {
                            if (this.IsAttackByPin(board.Array[i], pin))
                            {
                                k.NumberOfCheckingPieces++;
                                k.Checker = board.Array[i];
                                k.CheckRayLength = --checkP;
                                k.PinStatus |= pin;

                                Array.Copy(checkRay, 0, k.CheckRay, 0, k.CheckRayLength);
                            }
                        }
                        else
                        {
                            // The shield is pinned
                            if (this.IsAttackByPin(board.Array[i], pin))
                            {
                                // TODO: This might not work
                                ((Piece)board.Array[i]).PinStatus |= pin;
                            }
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether [the specified piece] [is under attack by direct pin]
        /// </summary>
        /// <param name="piece">The piece.</param>
        /// <param name="pin">The pin.</param>
        /// <returns><c>true</c> if [the specified piece] [is under attack by direct pin]; otherwise, <c>false</c>.</returns>
        private bool IsAttackByPin(IPiece piece, PinStatus pin)
        {
            if (pin == PinStatus.NS || pin == PinStatus.WE)
            {
                return piece is IStraightMoveable;
            }

            if (pin == PinStatus.NWSE || pin == PinStatus.SWNE)
            {
                return piece is IDiagonalMoveable;
            }

            return false;
        }

        /// <summary>
        /// Gets the possible moves.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="probeStart">The probe start.</param>
        /// <returns>System.Int32[][].</returns>
        private int[] GetPossibleMoves(IBoard board, int probeStart)
        {
            var moves = new int[256];

            if (board.SideToMove == PieceColor.White)
            {
                if (board.WhiteKing.NumberOfCheckingPieces == 0)
                {
                    return this.GenerateMovesForAllPieces(board, probeStart, moves);
                }
                
                if (board.WhiteKing.NumberOfCheckingPieces == 1)
                {
                    //return this.GenerateEvasions(probeStart, moves);
                }
                
                if (board.WhiteKing.NumberOfCheckingPieces >= 2)
                {
                    //return whiteKing.GetMoves(probeStart, moves);
                }
            }
            else
            {
                if (board.BlackKing.NumberOfCheckingPieces == 0)
                {
                    //return GenerateMovesForAllPieces(probeStart, moves);
                }
                
                if (board.BlackKing.NumberOfCheckingPieces == 1)
                {
                    //return GenerateEvasions(probeStart, moves);
                }
                
                if (board.BlackKing.NumberOfCheckingPieces >= 2)
                {
                    //return blackKing.GetMoves(probeStart, moves);
                }
            }

            return moves;
        }

        /// <summary>
        /// Generates the moves for all chess pieces on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="start">The start.</param>
        /// <param name="moves">The moves.</param>
        /// <returns>System.Int32.</returns>
        private int[] GenerateMovesForAllPieces(IBoard board, int start, int[] moves)
        {
            var begin = start;

            if (board.SideToMove == PieceColor.White)
            {
                foreach (Piece p in board.WhitePieces)
                {
                    if ((p.CurrentSquare & 0x88) == 0)
                    {
                        start += this.GetMovesForPiece(board, p, start, moves);
                    }
                }
            }
            else
            {
                foreach (Piece p in board.BlackPieces)
                {
                    if ((p.CurrentSquare & 0x88) == 0)
                    {
                        start += this.GetMovesForPiece(board, p, start, moves);
                    }
                }
            }

            return moves;
        }

        /// <summary>
        /// Gets the pseudo-legal moves for the specified piece.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="piece">The piece.</param>
        /// <param name="start">The start.</param>
        /// <param name="moves">The moves.</param>
        /// <returns>System.Int32.</returns>
        private int GetMovesForPiece(IBoard board, IPiece piece, int start, int[] moves)
        {
            if (piece.GetType() == typeof(Pawn))
            {
                return this.pawnMoveGenerator.GeneratePseudoLegalMoves(board, (Pawn)piece, start, moves);
            }

            return -1;
        }
    }
}