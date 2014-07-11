namespace ChessMoveValidator.Core.Models
{
    /// <summary>
    /// Represents the settings for the chess board.
    /// </summary>
    public class BoardSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardSettings"/> class.
        /// </summary>
        public BoardSettings()
        {
            this.FileCount = 8;
            this.RankCount = 8;
        }

        /// <summary>
        /// Gets or sets the number of files on the chess board.
        /// </summary>
        public int FileCount { get; set; }

        /// <summary>
        /// Gets or sets the number of ranks on the chess board.
        /// </summary>
        public int RankCount { get; set; }

        /// <summary>
        /// Gets the number of squares in the board.
        /// </summary>
        public int SquareCount
        {
            get
            {
                return this.RankCount * this.FileCount;
            }
        }
    }
}