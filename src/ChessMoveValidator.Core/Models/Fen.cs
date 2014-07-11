namespace ChessMoveValidator.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using ChessMoveValidator.Core.Enums;

    /// <summary>
    /// Represents a Forsyth–Edwards Notation (FEN) string.
    /// http://chessprogramming.wikispaces.com/Forsyth-Edwards+Notation
    /// </summary>
    public class Fen
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fen"/> class.
        /// </summary>
        public Fen()
        {
            this.Board = new Collection<Square>();
        }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        /// <value>The board.</value>
        public ICollection<Square> Board { get; set; }

        /// <summary>
        /// Gets or sets the color of the player to move.
        /// </summary>
        /// <value>The color of the player to move.</value>
        public PieceColor SideToMove { get; set; }

        /// <summary>
        /// Gets or sets the castling rights.
        /// </summary>
        /// <value>The castling rights.</value>
        public CastlingAvailability CastlingRights { get; set; }

        /// <summary>
        /// Gets or sets a decimal number of half moves with respect to the 50 move draw rule.
        /// </summary>
        /// <remarks>It is reset to zero after a capture or a pawn move and incremented otherwise.</remarks>
        /// <value>The halfmove clock.</value>
        public int HalfmoveClock { get; set; }

        /// <summary>
        /// Gets or sets the number of the full moves in a game.
        /// </summary>
        /// <remarks>It starts at 1, and is incremented after each Black's move.</remarks>
        /// <value>The fullmove counter.</value>
        public int FullmoveCounter { get; set; }

        /// <summary>
        /// Gets or sets the en passant square.
        /// </summary>
        /// <value>The en passant square.</value>
        public Square EnPassantSquare { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            // TODO: Should output FEN string
            return base.ToString();
        }
    }
}