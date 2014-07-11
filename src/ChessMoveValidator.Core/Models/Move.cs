namespace ChessMoveValidator.Core.Models
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a move on the chess board.
    /// </summary>
    [DebuggerDisplay("Algebraic Notation: {AlgebraicNotation, nq}, Descriptive Notation: {DescriptiveNotation, nq}")]
    public class Move
    {
        /// <summary>
        /// Gets or sets the start square.
        /// </summary>
        /// <value>The start square.</value>
        public Square StartSquare { get; set; }

        /// <summary>
        /// Gets or sets the end square.
        /// </summary>
        /// <value>The end square.</value>
        public Square EndSquare { get; set; }

        /// <summary>
        /// Gets the descriptive notation from white's viewpoint.
        /// </summary>
        /// <value>The descriptive notation from white's viewpoint.</value>
        public string DescriptiveNotation
        {
            get
            {
                throw new NotImplementedException();
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
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.AlgebraicNotation;
        }
    }
}