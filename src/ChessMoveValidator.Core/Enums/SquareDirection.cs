namespace ChessMoveValidator.Core.Enums
{
    /// <summary>
    /// Square direction on a 0x88 chess board.
    /// </summary>
    public static class SquareDirection
    {
        /// <summary>
        /// One square northwards
        /// </summary>
        public const int N = 16;

        /// <summary>
        /// Two squares northwards
        /// </summary>
        public const int NN = N + N;

        /// <summary>
        /// One square southwards
        /// </summary>
        public const int S = -16;

        /// <summary>
        /// Two squares southwards
        /// </summary>
        public const int SS = S + S;

        /// <summary>
        /// One square eastwards
        /// </summary>
        public const int E = 1;

        /// <summary>
        /// One square westwards
        /// </summary>
        public const int W = -1;

        /// <summary>
        /// One square northeastwards
        /// </summary>
        public const int NE = 17;

        /// <summary>
        /// One square southwestwards
        /// </summary>
        public const int SW = -17;

        /// <summary>
        /// One square northwestwards
        /// </summary>
        public const int NW = 15;

        /// <summary>
        /// One square southeastwards
        /// </summary>
        public const int SE = -15;
    }
}