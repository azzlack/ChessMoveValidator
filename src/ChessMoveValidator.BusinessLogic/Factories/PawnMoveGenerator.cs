namespace ChessMoveValidator.BusinessLogic.Factories
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Functions;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Move generator for the <see cref="Pawn"/> piece.
    /// </summary>
    public class PawnMoveGenerator : IPieceMoveGenerator<Pawn>
    {
        /// <summary>
        /// The board operations
        /// </summary>
        private readonly IBoardOperations boardOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="PawnMoveGenerator"/> class.
        /// </summary>
        /// <param name="boardOperations">The board operations.</param>
        public PawnMoveGenerator(IBoardOperations boardOperations)
        {
            this.boardOperations = boardOperations;
        }

        /// <summary>
        /// Generates pseudo-legal moves for the specified piece on the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="piece">The piece.</param>
        /// <param name="start">The start.</param>
        /// <param name="moves">The moves.</param>
        /// <returns>The number of moves.</returns>
        public int GeneratePseudoLegalMoves(IBoard board, Pawn piece, int start, int[] moves)
        {
            var begin = start;

            var lastRank = piece.Color == PieceColor.White ? 7 : 0;
            var oneStep = piece.Color == PieceColor.White ? 16 : -16;
            var twoStep = piece.Color == PieceColor.White ? 32 : -32;
            var rankForEnPassant = piece.Color == PieceColor.White ? 1 : 6;
            var rankForEnPassantCapture = piece.Color == PieceColor.White ? 4 : 3;
            var diag1 = piece.Color == PieceColor.White ? 17 : -17;
            var diag2 = piece.Color == PieceColor.White ? 15 : -15;

            //if (this.boardOperations.GetRank(piece.CurrentSquare) != lastRank && board.Array[piece.CurrentSquare + oneStep] == null && (piece.PinStatus == PinStatus.None || (piece.PinStatus & PinStatus.NS) != 0))
            //{
            //    moves[start++] = this.boardOperations.GetSquareIndexForMove(piece.CurrentSquare, piece.CurrentSquare + oneStep);

            //    if (this.boardOperations.GetRank(piece.CurrentSquare + oneStep) == lastRank)
            //    {
            //        var prom = moves[start - 1];
            //        moves[start - 1] |= this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Queen);
            //        moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Bishop);
            //        moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Rook);
            //        moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Knight);
            //    }

            //    if (this.boardOperations.GetRank(piece.CurrentSquare) == rankForEnPassant && board.Array[piece.CurrentSquare + twoStep] == null)
            //    {
            //        moves[start] = this.boardOperations.GetSquareIndexForMove(piece.CurrentSquare, piece.CurrentSquare + twoStep);
            //        MovePackHelper.GetCleanedMove(moves[start]);
            //        start++;
            //    }
            //}

            //if (this.boardOperations.GetRank(piece.CurrentSquare) != lastRank)
            //{
            //    if (piece.PinStatus == PinStatus.None || (piece.PinStatus & PinStatus.NS) == 0)
            //    {
            //        if (this.boardOperations.IsSquareValid(piece.CurrentSquare + diag1) && IsEnemy(piece.CurrentSquare + diag1) && PinCompatible(diag1))
            //        {
            //            moves[start++] = this.boardOperations.GetSquareIndexForCapture(board, piece, board.Array[piece.CurrentSquare + diag1]);

            //            if (this.boardOperations.GetRank(piece.CurrentSquare + diag1) == lastRank)
            //            {
            //                var prom = moves[start - 1];
            //                moves[start - 1] |= this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Queen);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Bishop);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Rook);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Knight);
            //            }
            //        }

            //        if (this.boardOperations.GetRank(piece.CurrentSquare + diag2) && IsEnemy(piece.CurrentSquare + diag2) && PinCompatible(diag2))
            //        {
            //            moves[start++] = this.boardOperations.GetSquareIndexForCapture(board, piece, board.Array[piece.CurrentSquare + diag2]);

            //            if (this.boardOperations.GetRank(piece.CurrentSquare + diag2) == lastRank)
            //            {
            //                var prom = moves[start - 1];
            //                moves[start - 1] |= this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Queen);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Bishop);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Rook);
            //                moves[start++] = prom | this.boardOperations.GetSquareIndexForPromotionMerge(Promotion.Knight);
            //            }
            //        }
                    
            //        // ep.
            //        if (this.boardOperations.GetRank(piece.CurrentSquare) == rankForEnPassantCapture)
            //        {
            //            if (this.boardOperations.IsSquareValid(piece.CurrentSquare + diag2) && piece.CurrentSquare + diag2 == board.EnPassantSquareIndex && PinCompatible(diag2) && board.CheckIfSafeEpCapture(board.SideToMove, piece.CurrentSquare))
            //            {
            //                moves[start++] = this.boardOperations.GetSquareIndexForMove(piece.CurrentSquare, piece.CurrentSquare + diag2) | MovePackHelper.EpFlag;
            //            }
            //            if (this.boardOperations.IsSquareValid(piece.CurrentSquare + diag1) && piece.CurrentSquare + diag1 == board.EnPassantSquareIndex && PinCompatible(diag1) && board.CheckIfSafeEpCapture(board.SideToMove, piece.CurrentSquare))
            //            {
            //                moves[start++] = this.boardOperations.GetSquareIndexForMove(piece.CurrentSquare, piece.CurrentSquare + diag1) | MovePackHelper.EpFlag;
            //            }
            //        }

            //    }
            //}

            return start - begin;
        }
    }
}