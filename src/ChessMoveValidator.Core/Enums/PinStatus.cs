namespace ChessMoveValidator.Core.Enums
{
    using System;

    /// <summary>
    /// Pin status for a piece
    /// </summary>
    [Flags]
    public enum PinStatus
    {
        /// <summary>
        /// Piece is not pinned
        /// </summary>
        None = 0,

        /// <summary>
        /// Piece is pinned from north or south
        /// </summary>
        NS = 1,

        /// <summary>
        /// Piece is pinned from west or east
        /// </summary>
        WE = 2,

        /// <summary>
        /// Piece is pinned from southwest or northeast
        /// </summary>
        SWNE = 4,

        /// <summary>
        /// Piece is pinned from northwest or southeast
        /// </summary>
        NWSE = 8
    }
}