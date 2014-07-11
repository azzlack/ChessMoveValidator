namespace ChessMoveValidator.Core.Models.Pieces
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Represents a king.
    /// </summary>
    public class King : Piece, ICastleable, ICheckable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="King" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public King(PieceColor color)
            : base(color)
        {
            this.CheckRay = new int[6];
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can castle king side.
        /// </summary>
        /// <value><c>true</c> if this instance can castle king side; otherwise, <c>false</c>.</value>
        public bool CanCastleKingSide { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can castle queen side.
        /// </summary>
        /// <value><c>true</c> if this instance can castle queen side; otherwise, <c>false</c>.</value>
        public bool CanCastleQueenSide { get; set; }

        /// <summary>
        /// Gets or sets the zobrist hash keys for castling.
        /// </summary>
        /// <value>The zobrist hash keys for castling.</value>
        public ulong[] ZobristHashKeysForCastling { get; set; }

        /// <summary>
        /// Gets or sets the number of pieces that are checking this instance.
        /// </summary>
        /// <value>The number of pieces that are checking this instance.</value>
        public int NumberOfCheckingPieces { get; set; }

        /// <summary>
        /// Gets or sets the piece that is currently checking this instance.
        /// </summary>
        /// <value>The piece that is currently checking this instance.</value>
        public IPiece Checker { get; set; }

        /// <summary>
        /// Gets or sets the indexes of the squares between this instance and the <c>Checker</c>.
        /// </summary>
        /// <value>The check ray.</value>
        public int[] CheckRay { get; set; }

        /// <summary>
        /// Gets or sets the number of squares between this instance and the <c>Checker</c>.
        /// </summary>
        /// <value>The length of the check ray.</value>
        public int CheckRayLength { get; set; }
    }
}