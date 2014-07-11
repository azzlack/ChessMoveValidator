namespace ChessMoveValidator.Core.Models
{
    using System.Diagnostics;

    /// <summary>
    /// Represents a square on a chess board.
    /// </summary>
    [DebuggerDisplay("Algebraic Notation: {AlgebraicNotation, nq}, Descriptive Notation: {DescriptiveNotation, nq}")]
    public class Square
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="rank">The rank.</param>
        /// <param name="file">The file.</param>
        public Square(int rank, int file)
        {
            this.Rank = rank;
            this.File = file;
        }

        /// <summary>
        /// Gets the rank (y-axis).
        /// </summary>
        /// <value>The rank.</value>
        public int Rank { get; private set; }

        /// <summary>
        /// Gets the file (x-axis).
        /// </summary>
        /// <value>The file.</value>
        public int File { get; private set; }

        /// <summary>
        /// Gets or sets the piece.
        /// </summary>
        /// <value>The piece.</value>
        public Piece Piece { get; set; }

        /// <summary>
        /// Gets the descriptive notation from white's viewpoint.
        /// </summary>
        /// <value>The descriptive notation from white's viewpoint.</value>
        public string DescriptiveNotation
        {
            get
            {
                return Enums.DescriptiveNotation.Squares[this.File][this.Rank];
            }
        }

        /// <summary>
        /// Gets the algebraic notation.
        /// </summary>
        /// <value>The algebraic notation.</value>
        public string AlgebraicNotation
        {
            get
            {
                return Enums.AlgebraicNotation.Squares[this.File][this.Rank];
            }
        }
    }
}