namespace ChessMoveValidator.Tests.Unit.Factories
{
    using ChessMoveValidator.BusinessLogic.Extensions;
    using ChessMoveValidator.BusinessLogic.Factories;
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Models.Pieces;

    using NUnit.Framework;

    [TestFixture]
    public class FenFactoryTests
    {
        private IFenFactory fenFactory;

        [SetUp]
        public void SetUp()
        {
            this.fenFactory = new FenFactory();
        }

        [Test]
        public void Create_WhenGivenFenStartPosition_ShouldCreateFenWithCorrectSquares()
        {
            var fen = this.fenFactory.Create("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            Assert.That(fen.Board.GetSquare(0, 0).Piece is Rook && fen.Board.GetSquare(0, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 1).Piece is Knight && fen.Board.GetSquare(0, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 2).Piece is Bishop && fen.Board.GetSquare(0, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 3).Piece is Queen && fen.Board.GetSquare(0, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 4).Piece is King && fen.Board.GetSquare(0, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 5).Piece is Bishop && fen.Board.GetSquare(0, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 6).Piece is Knight && fen.Board.GetSquare(0, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 7).Piece is Rook && fen.Board.GetSquare(0, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 0).Piece is Pawn && fen.Board.GetSquare(1, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 1).Piece is Pawn && fen.Board.GetSquare(1, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 2).Piece is Pawn && fen.Board.GetSquare(1, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 3).Piece is Pawn && fen.Board.GetSquare(1, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 4).Piece is Pawn && fen.Board.GetSquare(1, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 5).Piece is Pawn && fen.Board.GetSquare(1, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 6).Piece is Pawn && fen.Board.GetSquare(1, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 7).Piece is Pawn && fen.Board.GetSquare(1, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(2, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 0).Piece is Pawn && fen.Board.GetSquare(6, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 1).Piece is Pawn && fen.Board.GetSquare(6, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 2).Piece is Pawn && fen.Board.GetSquare(6, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 3).Piece is Pawn && fen.Board.GetSquare(6, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 4).Piece is Pawn && fen.Board.GetSquare(6, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 5).Piece is Pawn && fen.Board.GetSquare(6, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 6).Piece is Pawn && fen.Board.GetSquare(6, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 7).Piece is Pawn && fen.Board.GetSquare(6, 7).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 0).Piece is Rook && fen.Board.GetSquare(7, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 1).Piece is Knight && fen.Board.GetSquare(7, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 2).Piece is Bishop && fen.Board.GetSquare(7, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 3).Piece is Queen && fen.Board.GetSquare(7, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 4).Piece is King && fen.Board.GetSquare(7, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 5).Piece is Bishop && fen.Board.GetSquare(7, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 6).Piece is Knight && fen.Board.GetSquare(7, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 7).Piece is Rook && fen.Board.GetSquare(7, 7).Piece.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenSecondFenPosition_ShouldCreateFenWithCorrectSquares()
        {
            var fen = this.fenFactory.Create("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1");

            Assert.That(fen.Board.GetSquare(0, 0).Piece is Rook && fen.Board.GetSquare(0, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 1).Piece is Knight && fen.Board.GetSquare(0, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 2).Piece is Bishop && fen.Board.GetSquare(0, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 3).Piece is Queen && fen.Board.GetSquare(0, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 4).Piece is King && fen.Board.GetSquare(0, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 5).Piece is Bishop && fen.Board.GetSquare(0, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 6).Piece is Knight && fen.Board.GetSquare(0, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 7).Piece is Rook && fen.Board.GetSquare(0, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 0).Piece is Pawn && fen.Board.GetSquare(1, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 1).Piece is Pawn && fen.Board.GetSquare(1, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 2).Piece is Pawn && fen.Board.GetSquare(1, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 3).Piece is Pawn && fen.Board.GetSquare(1, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(1, 5).Piece is Pawn && fen.Board.GetSquare(1, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 6).Piece is Pawn && fen.Board.GetSquare(1, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 7).Piece is Pawn && fen.Board.GetSquare(1, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(2, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 4).Piece is Pawn && fen.Board.GetSquare(3, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(3, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 0).Piece is Pawn && fen.Board.GetSquare(6, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 1).Piece is Pawn && fen.Board.GetSquare(6, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 2).Piece is Pawn && fen.Board.GetSquare(6, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 3).Piece is Pawn && fen.Board.GetSquare(6, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 4).Piece is Pawn && fen.Board.GetSquare(6, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 5).Piece is Pawn && fen.Board.GetSquare(6, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 6).Piece is Pawn && fen.Board.GetSquare(6, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 7).Piece is Pawn && fen.Board.GetSquare(6, 7).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 0).Piece is Rook && fen.Board.GetSquare(7, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 1).Piece is Knight && fen.Board.GetSquare(7, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 2).Piece is Bishop && fen.Board.GetSquare(7, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 3).Piece is Queen && fen.Board.GetSquare(7, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 4).Piece is King && fen.Board.GetSquare(7, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 5).Piece is Bishop && fen.Board.GetSquare(7, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 6).Piece is Knight && fen.Board.GetSquare(7, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 7).Piece is Rook && fen.Board.GetSquare(7, 7).Piece.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenThirdFenPosition_ShouldCreateFenWithCorrectSquares()
        {
            var fen = this.fenFactory.Create("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2");

            Assert.That(fen.Board.GetSquare(0, 0).Piece is Rook && fen.Board.GetSquare(0, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 1).Piece is Knight && fen.Board.GetSquare(0, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 2).Piece is Bishop && fen.Board.GetSquare(0, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 3).Piece is Queen && fen.Board.GetSquare(0, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 4).Piece is King && fen.Board.GetSquare(0, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 5).Piece is Bishop && fen.Board.GetSquare(0, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 6).Piece is Knight && fen.Board.GetSquare(0, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 7).Piece is Rook && fen.Board.GetSquare(0, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 0).Piece is Pawn && fen.Board.GetSquare(1, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 1).Piece is Pawn && fen.Board.GetSquare(1, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 2).Piece is Pawn && fen.Board.GetSquare(1, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 3).Piece is Pawn && fen.Board.GetSquare(1, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(1, 5).Piece is Pawn && fen.Board.GetSquare(1, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 6).Piece is Pawn && fen.Board.GetSquare(1, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 7).Piece is Pawn && fen.Board.GetSquare(1, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(2, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 4).Piece is Pawn && fen.Board.GetSquare(3, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(3, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 2).Piece is Pawn && fen.Board.GetSquare(4, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(4, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 0).Piece is Pawn && fen.Board.GetSquare(6, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 1).Piece is Pawn && fen.Board.GetSquare(6, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 3).Piece is Pawn && fen.Board.GetSquare(6, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 4).Piece is Pawn && fen.Board.GetSquare(6, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 5).Piece is Pawn && fen.Board.GetSquare(6, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 6).Piece is Pawn && fen.Board.GetSquare(6, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 7).Piece is Pawn && fen.Board.GetSquare(6, 7).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 0).Piece is Rook && fen.Board.GetSquare(7, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 1).Piece is Knight && fen.Board.GetSquare(7, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 2).Piece is Bishop && fen.Board.GetSquare(7, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 3).Piece is Queen && fen.Board.GetSquare(7, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 4).Piece is King && fen.Board.GetSquare(7, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 5).Piece is Bishop && fen.Board.GetSquare(7, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 6).Piece is Knight && fen.Board.GetSquare(7, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 7).Piece is Rook && fen.Board.GetSquare(7, 7).Piece.Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenGivenFourthFenPosition_ShouldCreateFenWithCorrectSquares()
        {
            var fen = this.fenFactory.Create("rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2");

            Assert.That(fen.Board.GetSquare(0, 0).Piece is Rook && fen.Board.GetSquare(0, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 1).Piece is Knight && fen.Board.GetSquare(0, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 2).Piece is Bishop && fen.Board.GetSquare(0, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 3).Piece is Queen && fen.Board.GetSquare(0, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 4).Piece is King && fen.Board.GetSquare(0, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 5).Piece is Bishop && fen.Board.GetSquare(0, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(0, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(0, 7).Piece is Rook && fen.Board.GetSquare(0, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 0).Piece is Pawn && fen.Board.GetSquare(1, 0).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 1).Piece is Pawn && fen.Board.GetSquare(1, 1).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 2).Piece is Pawn && fen.Board.GetSquare(1, 2).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 3).Piece is Pawn && fen.Board.GetSquare(1, 3).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(1, 5).Piece is Pawn && fen.Board.GetSquare(1, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 6).Piece is Pawn && fen.Board.GetSquare(1, 6).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(1, 7).Piece is Pawn && fen.Board.GetSquare(1, 7).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(2, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 5).Piece is Knight && fen.Board.GetSquare(2, 5).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(2, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(2, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 4).Piece is Pawn && fen.Board.GetSquare(3, 4).Piece.Color == PieceColor.White);
            Assert.That(fen.Board.GetSquare(3, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(3, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 2).Piece is Pawn && fen.Board.GetSquare(4, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(4, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(4, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 0).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 1).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 3).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 4).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 5).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 6).Piece == null);
            Assert.That(fen.Board.GetSquare(5, 7).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 0).Piece is Pawn && fen.Board.GetSquare(6, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 1).Piece is Pawn && fen.Board.GetSquare(6, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 2).Piece == null);
            Assert.That(fen.Board.GetSquare(6, 3).Piece is Pawn && fen.Board.GetSquare(6, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 4).Piece is Pawn && fen.Board.GetSquare(6, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 5).Piece is Pawn && fen.Board.GetSquare(6, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 6).Piece is Pawn && fen.Board.GetSquare(6, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(6, 7).Piece is Pawn && fen.Board.GetSquare(6, 7).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 0).Piece is Rook && fen.Board.GetSquare(7, 0).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 1).Piece is Knight && fen.Board.GetSquare(7, 1).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 2).Piece is Bishop && fen.Board.GetSquare(7, 2).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 3).Piece is Queen && fen.Board.GetSquare(7, 3).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 4).Piece is King && fen.Board.GetSquare(7, 4).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 5).Piece is Bishop && fen.Board.GetSquare(7, 5).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 6).Piece is Knight && fen.Board.GetSquare(7, 6).Piece.Color == PieceColor.Black);
            Assert.That(fen.Board.GetSquare(7, 7).Piece is Rook && fen.Board.GetSquare(7, 7).Piece.Color == PieceColor.Black);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectNumberOfSquares(string fenPosition)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.Board.Count == 64);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", PieceColor.White)]
        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 0 1", PieceColor.Black)]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectSideToMove(string fenPosition, PieceColor colorToMove)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.SideToMove == colorToMove);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", CastlingAvailability.KingSideWhite | CastlingAvailability.QueenSideWhite | CastlingAvailability.KingSideBlack | CastlingAvailability.QueenSideBlack )]
        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w Kq - 0 1", CastlingAvailability.KingSideWhite | CastlingAvailability.QueenSideBlack )]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectSideToMove(string fenPosition, CastlingAvailability castlingRights)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.AreEqual(fen.CastlingRights, castlingRights);
        }

        [TestCase("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2", 5, 2)]
        [TestCase("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq e3 0 2", 2, 4)]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectEnPassant(string fenPosition, int rank, int file)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.EnPassantSquare.Rank == rank);
            Assert.That(fen.EnPassantSquare.File == file);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w Kq - 0 1")]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectEnPassant(string fenPosition)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.EnPassantSquare == null);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", 0)]
        [TestCase("rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2", 1)]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectHalfmoveClock(string fenPosition, int halfmoveClock)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.HalfmoveClock == halfmoveClock);
        }

        [TestCase("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", 1)]
        [TestCase("rnbqkbnr/pp1ppppp/8/2p5/4P3/8/PPPP1PPP/RNBQKBNR w KQkq c6 0 2", 2)]
        [TestCase("rnbqkbnr/pp1ppppp/8/2p5/4P3/5N2/PPPP1PPP/RNBQKB1R b KQkq - 1 2", 2)]
        public void Create_WhenGivenFenPosition_ShouldCreateFenWithCorrectFullmoveCounter(string fenPosition, int fullmoveCounter)
        {
            var fen = this.fenFactory.Create(fenPosition);

            Assert.That(fen.FullmoveCounter == fullmoveCounter);
        }
    }
}