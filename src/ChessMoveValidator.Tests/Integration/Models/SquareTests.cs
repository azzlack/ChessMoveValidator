namespace ChessMoveValidator.Tests.Integration.Models
{
    using ChessMoveValidator.Core.Models;

    using NUnit.Framework;

    [TestFixture]
    public class SquareTests
    {
        [TestCase(0, 0, "A1")]
        [TestCase(1, 0, "A2")]
        [TestCase(1, 1, "B2")]
        [TestCase(2, 1, "B3")]
        [TestCase(2, 2, "C3")]
        [TestCase(3, 2, "C4")]
        [TestCase(3, 3, "D4")]
        [TestCase(4, 3, "D5")]
        [TestCase(4, 4, "E5")]
        [TestCase(5, 4, "E6")]
        [TestCase(5, 5, "F6")]
        [TestCase(6, 5, "F7")]
        [TestCase(6, 6, "G7")]
        [TestCase(7, 6, "G8")]
        [TestCase(7, 7, "H8")]
        public void AlgebraicNotation_WhenGivenRankAndFile_ShouldReturnCorrectNotation(int rank, int file, string expectedResult)
        {
            var square = new Square(rank, file);

            Assert.AreEqual(square.AlgebraicNotation, expectedResult);
        }

        [TestCase(0, 0, "QR1")]
        [TestCase(1, 0, "QR2")]
        [TestCase(1, 1, "QN2")]
        [TestCase(2, 1, "QN3")]
        [TestCase(2, 2, "QB3")]
        [TestCase(3, 2, "QB4")]
        [TestCase(3, 3, "Q4")]
        [TestCase(4, 3, "Q5")]
        [TestCase(4, 4, "K5")]
        [TestCase(5, 4, "K6")]
        [TestCase(5, 5, "KB6")]
        [TestCase(6, 5, "KB7")]
        [TestCase(6, 6, "KN7")]
        [TestCase(7, 6, "KN8")]
        [TestCase(7, 7, "KR8")]
        public void DescriptiveNotation_WhenGivenRankAndFile_ShouldReturnCorrectNotation(int rank, int file, string expectedResult)
        {
            var square = new Square(rank, file);

            Assert.AreEqual(square.DescriptiveNotation, expectedResult);
        }
    }
}