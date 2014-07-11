namespace ChessMoveValidator.Core.Enums
{
    /// <summary>
    /// Represents pawn promotions
    /// </summary>
    public enum Promotion
    {
        /// <summary>
        /// Indicates promotion to queen
        /// </summary>
        Queen = 1,

        /// <summary>
        /// Indicates promotion to rook
        /// </summary>
        Rook = 2,

        /// <summary>
        /// Indicates promotion to bishop
        /// </summary>
        Bishop = 3,

        /// <summary>
        /// Indicates promotion to knight
        /// </summary>
        Knight = 4,

        /// <summary>
        /// Indicates no promotion
        /// </summary>
        None = 0
    }
}