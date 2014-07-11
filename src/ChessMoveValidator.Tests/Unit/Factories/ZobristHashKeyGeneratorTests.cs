namespace ChessMoveValidator.Tests.Unit.Factories
{
    using System.Linq;

    using ChessMoveValidator.BusinessLogic.Factories;
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Models.Pieces;

    using NUnit.Framework;

    [TestFixture]
    public class ZobristHashKeyGeneratorTests
    {
        private IZobristHashKeyGenerator hashKeyGenerator;

        [SetUp]
        public void SetUp()
        {
            this.hashKeyGenerator = new ZobristHashKeyGenerator();
        }

        [Test]
        public void Generate_WhenGivenTwoPawnsOfSameColor_ShouldReturnSameHashKeys()
        {
            var piece1 = new Pawn(PieceColor.White);
            var piece2 = new Pawn(PieceColor.White);

            this.hashKeyGenerator.Generate(piece1);
            this.hashKeyGenerator.Generate(piece2);

            CollectionAssert.AreEqual(piece1.ZobristHashKeys.White, piece2.ZobristHashKeys.White);
            CollectionAssert.AreEqual(piece1.ZobristHashKeys.Black, piece2.ZobristHashKeys.Black);
        }

        [Test]
        public void Generate_WhenGivenTwoPawnsOfDifferentColor_ShouldReturnSameHashKeys()
        {
            var piece1 = new Pawn(PieceColor.White);
            var piece2 = new Pawn(PieceColor.Black);

            this.hashKeyGenerator.Generate(piece1);
            this.hashKeyGenerator.Generate(piece2);

            CollectionAssert.AreEqual(piece1.ZobristHashKeys.White, piece2.ZobristHashKeys.White);
            CollectionAssert.AreEqual(piece1.ZobristHashKeys.Black, piece2.ZobristHashKeys.Black);
        }

        [Test]
        public void Generate_WhenGivenPawn_ShouldReturnCorrectHashKeys()
        {
            var piece = new Pawn(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
        }

        [Test]
        public void Generate_WhenGivenBishop_ShouldReturnCorrectHashKeys()
        {
            var piece = new Bishop(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
        }

        [Test]
        public void Generate_WhenGivenKnight_ShouldReturnCorrectHashKeys()
        {
            var piece = new Knight(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
        }

        [Test]
        public void Generate_WhenGivenRook_ShouldReturnCorrectHashKeys()
        {
            var piece = new Rook(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeysForCastling.ToList().Count == 16);
        }

        [Test]
        public void Generate_WhenGivenQueen_ShouldReturnCorrectHashKeys()
        {
            var piece = new Queen(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
        }

        [Test]
        public void Generate_WhenGivenKing_ShouldReturnCorrectHashKeys()
        {
            var piece = new King(PieceColor.White);

            this.hashKeyGenerator.Generate(piece);

            Assert.That(piece.ZobristHashKeys.White.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeys.Black.ToList().Count == 128);
            Assert.That(piece.ZobristHashKeysForCastling.ToList().Count == 16);
        }
    }
}