namespace ChessMoveValidator.Core.Converters
{
    using System;

    public static class IntConverter
    {
        /// <summary>
        /// Converts the <paramref name="number" /> to a binary representation for use in 0x88 chess boards.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>A binary representation.</returns>
        public static string ToBinary(int number)
        {
            var str = Convert.ToString(number, 2);
            str = str.PadLeft(8, '0');

            return str;
        }
    }
}
