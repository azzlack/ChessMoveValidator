namespace ChessMoveValidator.Core.Models
{
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// The game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            this.History = new Collection<Board>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        public Collection<Board> History { get; set; }

        /// <summary>
        /// Gets or sets the white player (challenger).
        /// </summary>
        /// <value>
        /// The white player (challenger).
        /// </value>
        public Player White { get; set; }

        /// <summary>
        /// Gets or sets the black player (opponent).
        /// </summary>
        /// <value>
        /// The black player (opponent).
        /// </value>
        public Player Black { get; set; }

        /// <summary>
        /// Gets the current board.
        /// </summary>
        /// <value>
        /// The current board.
        /// </value>
        public Board Board
        {
            get
            {
                return this.History.LastOrDefault();
            }
        }
    }
}