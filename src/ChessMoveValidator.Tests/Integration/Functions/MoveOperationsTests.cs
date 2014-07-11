namespace ChessMoveValidator.Tests.Integration.Functions
{
    using System;
    using System.Linq;

    using ChessMoveValidator.BusinessLogic.Factories;
    using ChessMoveValidator.BusinessLogic.Functions;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Interfaces.Functions;
    using ChessMoveValidator.Core.Models;

    using NUnit.Framework;

    [TestFixture]
    public class MoveOperationsTests
    {
        private IMoveOperations moveOperations;

        private IFenFactory fenFactory;

        private IBoardFactory boardFactory;

        [SetUp]
        public void SetUp()
        {
            this.moveOperations = new MoveOperations(new Ox88BoardOperations(), new PawnMoveGenerator(new Ox88BoardOperations()));
            this.fenFactory = new FenFactory();
            this.boardFactory = new BoardFactory(new ZobristHashKeyGenerator(), new PieceFactory(new ZobristHashKeyGenerator()), new Ox88BoardOperations());
        }

        [Test]
        public void ParseMoves_WhenGivenBoardsWithMoves_ShouldReturnMove()
        {
            var board1 = this.boardFactory.Create(this.fenFactory.Create());
            var board2 = this.boardFactory.Create(this.fenFactory.Create("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1"));

            var move = this.moveOperations.ParseMoves(board1, board2);

            Assert.That(move.First().StartSquare.File == 4 && move.First().StartSquare.Rank == 1);
            Assert.That(move.First().EndSquare.File == 4 && move.First().EndSquare.Rank == 3);
        }

        [Test]
        public void ParseMoves_WhenGivenBoardsWithNoMoves_ShouldThrowException()
        {
            var board1 = this.boardFactory.Create(this.fenFactory.Create());
            var board2 = this.boardFactory.Create(this.fenFactory.Create());

            Assert.Throws<ArgumentException>(() => this.moveOperations.ParseMoves(board1, board2));
        }

        [Test]
        public void Move_WhenGivenValidBoardMove_ShouldNotThrowException()
        {
            var board = this.boardFactory.Create(this.fenFactory.Create());

            // 1.e4 e5 
            // 2.Nf3 Nc6 
            // 3.Bb5 a6
            var move1 = new Move() { StartSquare = new Square(1, 4), EndSquare = new Square(3, 4) };
            var move2 = new Move() { StartSquare = new Square(6, 4), EndSquare = new Square(4, 4) };
            var move3 = new Move() { StartSquare = new Square(0, 6), EndSquare = new Square(2, 4) };
            var move4 = new Move() { StartSquare = new Square(7, 1), EndSquare = new Square(5, 2) };
            var move5 = new Move() { StartSquare = new Square(0, 5), EndSquare = new Square(4, 1) };
            var move6 = new Move() { StartSquare = new Square(6, 0), EndSquare = new Square(5, 0) };

            this.moveOperations.Move(board, move1);
            this.moveOperations.Move(board, move2);
            this.moveOperations.Move(board, move3);
            this.moveOperations.Move(board, move4);
            this.moveOperations.Move(board, move5);
            this.moveOperations.Move(board, move6);
        }

        public void Move_WhenGivenValidAlgebraicMoves_ShouldNotThrowException()
        {
            var board = this.boardFactory.Create(this.fenFactory.Create());

            // 1.e4 e5 
            // 2.Nf3 Nc6 
            // 3.Bb5 a6
            this.moveOperations.Move(board, "e4");
            this.moveOperations.Move(board, "e5");
            this.moveOperations.Move(board, "Nf3");
            this.moveOperations.Move(board, "Nc6");
            this.moveOperations.Move(board, "Bb5");
            this.moveOperations.Move(board, "a6");
        }

        [Test]
        public void Move_WhenGivenInvalidBoardMove_ShouldThrowException()
        {
            var board = this.boardFactory.Create(this.fenFactory.Create());
            var move = new Move() { StartSquare = new Square(1, 4), EndSquare = new Square(4, 4) };

            Assert.Throws<ArgumentException>(() => this.moveOperations.Move(board, move));
        }
    }
}