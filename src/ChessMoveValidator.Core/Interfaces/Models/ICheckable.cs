namespace ChessMoveValidator.Core.Interfaces.Models
{
    /// <summary>
    /// Interface for pieces that are checkable (Kings)
    /// </summary>
    public interface ICheckable : IPiece
    {
        /// <summary>
        /// Gets or sets the number of pieces that are checking this instance.
        /// </summary>
        /// <value>The number of pieces that are checking this instance.</value>
        int NumberOfCheckingPieces { get; set; }

        /// <summary>
        /// Gets or sets the piece that is currently checking this instance.
        /// </summary>
        /// <value>The piece that is currently checking this instance.</value>
        IPiece Checker { get; set; }

        /// <summary>
        /// Gets or sets the indexes of the squares between this instance and the <c>Checker</c>.
        /// </summary>
        /// <value>The check ray.</value>
        int[] CheckRay { get; set; }

        /// <summary>
        /// Gets or sets the number of squares between this instance and the <c>Checker</c>.
        /// </summary>
        /// <value>The length of the check ray.</value>
        int CheckRayLength { get; set; }
    }
}