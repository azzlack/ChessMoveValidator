namespace ChessMoveValidator.Tests.Unit.Handlers
{
    using ChessMoveValidator.BusinessLogic.Functions;
    using ChessMoveValidator.Core.Interfaces.Functions;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="Ox88BoardOperations"/> class.
    /// </summary>
    /// <remarks>
    ///   Square indexes:
    ///    ´ + ------------------------------- + -------------------------------- +
    ///    7 | 112 113 114 115 116 117 118 119 | 120 121 122 123 124 125 126 127 |
    ///    6 | 96  97  98  99  100 101 102 103 | 104 105 106 107 108 109 110 111 |
    /// R  5 | 80  81  82  83  84  85  86  87  | 88  89  90  91  92  93  94  95  |
    /// A  4 | 64  65  66  67  68  69  70  71  | 72  73  74  75  76  77  78  79  |
    /// N  3 | 48  49  50  51  52  53  54  55  | 56  57  58  59  60  61  62  63  |
    /// K  2 | 32  33  34  35  36  37  38  39  | 40  41  42  43  44  45  46  47  |
    ///    1 | 16  17  18  19  20  21  22  23  | 24  25  26  27  28  29  30  31  |
    ///    0 | 0   1   2   3   4   5   6   7   | 8   9   10  11  12  13  14  15  |
    ///      + ------------------------------- + -------------------------------- +
    ///        0   1   2   3   4   5   6   7
    ///                   F I L E
    /// </remarks>
    [TestFixture]
    [Category("Unit")]
    public class Ox88BoardOperationsTests
    {
        private IBoardOperations boardOperations;

        [SetUp]
        public void SetUp()
        {
            this.boardOperations = new Ox88BoardOperations();
        }

        [TestCase(1, 1)]
        [TestCase(7, 7)]
        [TestCase(17, 1)]
        [TestCase(34, 2)]
        public void GetFile_WhenGivenValidSquareIndex_ShouldReturnCorrectFile(int squareIndex, int expectedFile)
        {
            var file = this.boardOperations.GetFile(squareIndex);

            Assert.AreEqual(expectedFile, file);
        }

        [TestCase(18, 1)]
        [TestCase(23, 1)]
        public void GetFile_WhenGivenInvalidSquareIndex_ShouldReturnCorrectFile(int squareIndex, int expectedFile)
        {
            var file = this.boardOperations.GetFile(squareIndex);

            Assert.AreNotEqual(expectedFile, file);
        }

        [TestCase(1, 0)]
        [TestCase(8, 0)]
        [TestCase(17, 1)]
        [TestCase(118, 7)]
        public void GetRank_WhenGivenValidSquareIndex_ShouldReturnCorrectRank(int squareIndex, int expectedRank)
        {
            var rank = this.boardOperations.GetRank(squareIndex);

            Assert.AreEqual(expectedRank, rank);
        }

        [TestCase(18, 0)]
        [TestCase(64, 1)]
        public void GetRank_WhenGivenInvalidSquareIndex_ShouldReturnCorrectRank(int squareIndex, int expectedRank)
        {
            var rank = this.boardOperations.GetRank(squareIndex);

            Assert.AreNotEqual(expectedRank, rank);
        }

        [TestCase(18)]
        [TestCase(64)]
        [TestCase(100)]
        public void IsSquareValid_WhenGivenValidSquare_ShouldReturnTrue(int squareIndex)
        {
            var valid = this.boardOperations.IsSquareValid(squareIndex);

            Assert.IsTrue(valid);
        }

        [TestCase(11)]
        [TestCase(27)]
        [TestCase(90)]
        public void IsSquareValid_WhenGivenInvalidSquare_ShouldReturnFalse(int squareIndex)
        {
            var valid = this.boardOperations.IsSquareValid(squareIndex);

            Assert.IsFalse(valid);
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 1, 16)]
        [TestCase(7, 7, 119)]
        [TestCase(3, 3, 51)]
        [TestCase(5, 5, 85)]
        public void GetSquareIndex_WhenGivenValidFileAndRank_ShouldReturnCorrectSquare(int file, int rank, int expectedSquareIndex)
        {
            var s = this.boardOperations.GetSquareIndex(file, rank);

            Assert.That(s == expectedSquareIndex);
        }
    }
}
