namespace ChessMoveValidator.BusinessLogic.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using ChessMoveValidator.Core.Models;

    public static class SquareCollectionExtensions
    {
        /// <summary>
        /// Gets the square.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="rank">The rank.</param>
        /// <param name="file">The file.</param>
        /// <returns>The Square.</returns>
        public static Square GetSquare(this ICollection<Square> collection, int rank, int file)
        {
            return collection.Single(x => x.Rank == rank && x.File == file);
        }
    }
}