namespace ChessMoveValidator.Core.Models
{
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;

    /// <summary>
    /// Represents a chess piece.
    /// </summary>
    public abstract class Piece : IPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Piece" /> class.
        /// </summary>
        /// <param name="color">The color.</param>
        protected Piece(PieceColor color)
        {
            this.ZobristHashKeys = new ZobristHashKeyCollection();

            this.Color = color;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        /// <remarks>Should return a <a href="http://chessprogramming.wikispaces.com/Zobrist+Hashing">Zobrist hash key</a>.</remarks>
        public ulong Key
        {
            get
            {
                return this.GetKey(this.CurrentSquare);
            }
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <value>The color.</value>
        public PieceColor Color { get; private set; }

        /// <summary>
        /// Gets or sets the current square.
        /// </summary>
        /// <value>The current square.</value>
        public int CurrentSquare { get; set; }

        /// <summary>
        /// Gets or sets the pin status.
        /// </summary>
        /// <value>The pin status.</value>
        public PinStatus PinStatus { get; set; }

        /// <summary>
        /// Gets the zobrist hash keys for the specified piece.
        /// </summary>
        /// <value>The zobrist hash keys.</value>
        public ZobristHashKeyCollection ZobristHashKeys { get; private set; }

        /// <summary>
        /// Gets the Zobrist hash key for this piece at the specified square.
        /// </summary>
        /// <param name="square">The square index.</param>
        /// <returns>A unique hash key.</returns>
        public ulong GetKey(int square)
        {
            return this.Color == PieceColor.White
                       ? this.ZobristHashKeys.White[square]
                       : this.ZobristHashKeys.Black[square];
        }
    }
}