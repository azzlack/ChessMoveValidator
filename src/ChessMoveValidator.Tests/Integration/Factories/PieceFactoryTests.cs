namespace ChessMoveValidator.Tests.Integration.Factories
{
    using System;

    using ChessMoveValidator.BusinessLogic.Factories;
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    using NUnit.Framework;

    [TestFixture]
    public class PieceFactoryTests
    {
        private IPieceFactory pieceFactory { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.pieceFactory = new PieceFactory(new ZobristHashKeyGenerator());
        }

        [Test]
        public void Create_WhenGivenInvalidPieceType_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.pieceFactory.Create<Piece>(PieceColor.Black));
        }

        [Test]
        public void Create_WhenGivenWhitePawn_ShouldReturnWhitePawn()
        {
            var p = this.pieceFactory.Create<Pawn>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackPawn_ShouldReturnBlackPawn()
        {
            var p = this.pieceFactory.Create<Pawn>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenWhiteRook_ShouldReturnWhiteRook()
        {
            var p = this.pieceFactory.Create<Rook>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackRook_ShouldReturnBlackRook()
        {
            var p = this.pieceFactory.Create<Rook>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenWhiteKnight_ShouldReturnWhiteKnight()
        {
            var p = this.pieceFactory.Create<Knight>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackKnight_ShouldReturnBlackKnight()
        {
            var p = this.pieceFactory.Create<Knight>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenWhiteBishop_ShouldReturnWhiteBishop()
        {
            var p = this.pieceFactory.Create<Bishop>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackBishop_ShouldReturnBlackBishop()
        {
            var p = this.pieceFactory.Create<Bishop>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenWhiteQueen_ShouldReturnWhiteQueen()
        {
            var p = this.pieceFactory.Create<Queen>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackQueen_ShouldReturnBlackQueen()
        {
            var p = this.pieceFactory.Create<Queen>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenWhiteKing_ShouldReturnWhiteKing()
        {
            var p = this.pieceFactory.Create<King>(PieceColor.White);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.White);
        }

        [Test]
        public void Create_WhenGivenBlackKing_ShouldReturnBlackKing()
        {
            var p = this.pieceFactory.Create<King>(PieceColor.Black);

            Assert.IsNotNull(p);
            Assert.That(p.Color == PieceColor.Black);
        }
    }
}