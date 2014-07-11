namespace ChessMoveValidator.Core.Enums
{
    /// <summary>
    /// Old notation for recording chess games.
    /// </summary>
    public static class DescriptiveNotation
    {
        /// <summary>
        /// Gets the square names.
        /// </summary>
        /// <value>The square names.</value>
        public static string[][] Squares
        {
            get
            {
                return new[]
                           {
                               new[] { "QR1", "QR2", "QR3", "QR4", "QR5", "QR6", "QR7", "QR8" },
                               new[] { "QN1", "QN2", "QN3", "QN4", "QN5", "QN6", "QN7", "QN8" },
                               new[] { "QB1", "QB2", "QB3", "QB4", "QB5", "QB6", "QB7", "QB8" },
                               new[] { "Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8" },
                               new[] { "K1", "K2", "K3", "K4", "K5", "K6", "K7", "K8" },
                               new[] { "KB1", "KB2", "KB3", "KB4", "KB5", "KB6", "KB7", "KB8" },
                               new[] { "KN1", "KN2", "KN3", "KN4", "KN5", "KN6", "KN7", "KN8" },
                               new[] { "KR1", "KR2", "KR3", "KR4", "KR5", "KR6", "KR7", "KR8" }
                           };
            }
        }
    }
}