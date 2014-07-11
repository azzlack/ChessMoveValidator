namespace ChessMoveValidator.BusinessLogic.Functions
{
    using System;
    using System.Diagnostics;

    using ChessMoveValidator.Core.Converters;
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Functions;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models;

    /// <summary>
    /// Function library for 0x88 chess board operations.
    /// </summary>
    public class Ox88BoardOperations : IBoardOperations
    {
        /// <summary>
        /// Determines whether [the specified square index] [is a valid square].
        /// </summary>
        /// <param name="squareIndex">The square index.</param>
        /// <returns><c>true</c> if [the specified square index] [is a valid square]; otherwise, <c>false</c>.</returns>
        public bool IsSquareValid(int squareIndex)
        {
            var r = squareIndex & 0x88;

            Debug.WriteLine(
                string.Format(
                    "{0} & {1} = {2} ({3})",
                    IntConverter.ToBinary(squareIndex),
                    IntConverter.ToBinary(0x88),
                    IntConverter.ToBinary(r),
                    r == 0 ? "Valid" : "Invalid"),
                string.Format("IBoardOperations.IsSquareValid({0})", squareIndex));

            return r == 0;
        }

        /// <summary>
        /// Gets the file for the square index at the specified index.
        /// </summary>
        /// <param name="squareIndex">The square index.</param>
        /// <returns>The file.</returns>
        public int GetFile(int squareIndex)
        {
            var file = squareIndex & 0xF;

            Debug.WriteLine(
                string.Format(
                    "{0} & {1} = {2}",
                    IntConverter.ToBinary(squareIndex),
                    IntConverter.ToBinary(0xF),
                    file),
                string.Format("IBoardOperations.GetFile({0})", squareIndex));

            return file;
        }

        /// <summary>
        /// Gets the rank for the square index at the specified index.
        /// </summary>
        /// <param name="squareIndex">The square index.</param>
        /// <returns>The rank.</returns>
        public int GetRank(int squareIndex)
        {
            var rank = squareIndex >> 4;

            Debug.WriteLine(
                string.Format(
                    "{0} >> {1} = {2}",
                    IntConverter.ToBinary(squareIndex),
                    4,
                    rank),
                string.Format("IBoardOperations.GetRank({0})", squareIndex));

            return rank;
        }

        /// <summary>
        /// Gets the index of the square index in the <c>Array</c> at the specified file and rank.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="rank">The rank.</param>
        /// <returns>The square index.</returns>
        public int GetSquareIndex(int file, int rank)
        {
            var i = (16 * rank) + file;
            
            Debug.WriteLine(
                string.Format(
                    "(16 * {0}) + {1} = {2}",
                    file,
                    rank,
                    i),
                string.Format("IBoardOperations.GetSquareIndex({0}, {1})", file, rank));

            return i;
        }

        /// <summary>
        /// Gets the index of the square index in the <c>Array</c> that represents the capture move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="moving">The moving piece.</param>
        /// <param name="captured">The captured piece.</param>
        /// <returns>The square index.</returns>
        public int GetSquareIndexForCapture(IBoard board, IPiece moving, IPiece captured)
        {
            var m = (Piece)moving;
            var c = (Piece)captured;

            // TODO: GetCaptureDescriberFunction might be needed - keeping it here until sure
            // return m.CurrentSquare | (c.CurrentSquare << 8) | this.GetCaptureDescriber(m, c) | this.GetCaptureCastlingSquareIndex(c.CurrentSquare, board.CastlingAvailability);
            return m.CurrentSquare | (c.CurrentSquare << 8) | this.GetCaptureCastlingSquareIndex(c.CurrentSquare, board.CastlingAvailability);
        }

        /// <summary>
        /// Gets The square index for the move.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>The square index.</returns>
        public int GetSquareIndexForMove(int start, int end)
        {
            Debug.WriteLine("Start", Convert.ToString(start, 2));
            Debug.WriteLine("End", Convert.ToString(end, 2));

            var result = start | (end << 8);

            Debug.WriteLine("Result", Convert.ToString(result, 2));

            return result;
        }

        /// <summary>
        /// Gets the promotion merge.
        /// TODO: Better documentation
        /// </summary>
        /// <param name="promotion">The promotion.</param>
        /// <returns>System.Int32.</returns>
        public int GetSquareIndexForPromotionMerge(Promotion promotion)
        {
            return (int)promotion << 27;
        }

        /// <summary>
        /// Gets the castling merge.
        /// TODO: Better documentation
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <returns>System.Int32.</returns>
        public int GetCastlingMergeSquareIndex(int mask)
        {
            return mask << 21;
        }

        /// <summary>
        /// Gets the index of the capture castling squareIndex.
        /// TODO: Better documentation
        /// </summary>
        /// <param name="captureSquare">The capture squareIndex.</param>
        /// <param name="castlingStatus">The castling status.</param>
        /// <returns>System.Int32.</returns>
        private int GetCaptureCastlingSquareIndex(int captureSquare, CastlingAvailability castlingStatus)
        {
            switch (captureSquare)
            {
                case SquareIndex.A1:
                    return this.GetCastlingMergeSquareIndex((int)(castlingStatus & CastlingAvailability.QueenSideWhite));
                case SquareIndex.H1:
                    return this.GetCastlingMergeSquareIndex((int)(castlingStatus & CastlingAvailability.KingSideWhite));
                case SquareIndex.A8:
                    return this.GetCastlingMergeSquareIndex((int)(castlingStatus & CastlingAvailability.QueenSideBlack));
                case SquareIndex.H8:
                    return this.GetCastlingMergeSquareIndex((int)(castlingStatus & CastlingAvailability.KingSideBlack));
            }

            return 0;
        }
    }
}