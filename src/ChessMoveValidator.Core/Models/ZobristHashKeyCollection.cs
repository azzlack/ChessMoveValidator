namespace ChessMoveValidator.Core.Models
{
    /// <summary>
    /// Collection for Zobrist hash keys for each side.
    /// </summary>
    public class ZobristHashKeyCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZobristHashKeyCollection"/> class.
        /// </summary>
        public ZobristHashKeyCollection()
        {
            this.White = new ulong[128];
            this.Black = new ulong[128];
        }

        /// <summary>
        /// Gets or sets the hash keys for White.
        /// </summary>
        /// <value>The hash keys for white.</value>
        public ulong[] White { get; set; }

        /// <summary>
        /// Gets or sets the hash keys for Black.
        /// </summary>
        /// <value>The hash keys for Black.</value>
        public ulong[] Black { get; set; }
    }
}