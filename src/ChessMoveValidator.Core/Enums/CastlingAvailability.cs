namespace ChessMoveValidator.Core.Enums
{
    using System;

    /// <summary>
    /// Represents castling availability
    /// </summary>
    [Flags]
    public enum CastlingAvailability
    {
        /// <summary>
        /// White king can castle right.
        /// </summary>
        KingSideWhite = 1,

        /// <summary>
        /// White king can castle left.
        /// </summary>
        QueenSideWhite = 2,

        /// <summary>
        /// Black king can castle right.
        /// </summary>
        KingSideBlack = 4,

        /// <summary>
        /// Black king can castle left.
        /// </summary>
        QueenSideBlack = 8,

        /// <summary>
        /// No king can castle.
        /// </summary>
        None = 0,

        /// <summary>
        /// All kings can castle left and right.
        /// </summary>
        All = KingSideWhite | KingSideBlack | QueenSideWhite | QueenSideBlack
    }
}