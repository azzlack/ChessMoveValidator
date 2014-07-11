namespace ChessMoveValidator.Tests.Integration.Factories
{
    using ChessMoveValidator.BusinessLogic.Factories;
    using ChessMoveValidator.BusinessLogic.Functions;
    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Models.Pieces;

    using NUnit.Framework;

    [TestFixture]
    public class BoardFactoryTests
    {
        private IFenFactory fenFactory;

        private IBoardFactory boardFactory;

        [SetUp]
        public void SetUp()
        {
            this.boardFactory = new BoardFactory(new ZobristHashKeyGenerator(), new PieceFactory(new ZobristHashKeyGenerator()), new Ox88BoardOperations());
            this.fenFactory = new FenFactory();
        }

        [Test]
        public void Create_WhenCalled_ShouldCreateBoardWithDefaultPosition()
        {
            var f = this.fenFactory.Create();
            var b = this.boardFactory.Create(f);

            // Rank 1
            Assert.That(b.Array[0] is Rook && b.Array[0].Color == PieceColor.White);
            Assert.That(b.Array[1] is Knight && b.Array[1].Color == PieceColor.White);
            Assert.That(b.Array[2] is Bishop && b.Array[2].Color == PieceColor.White);
            Assert.That(b.Array[3] is Queen && b.Array[3].Color == PieceColor.White);
            Assert.That(b.Array[4] is King && b.Array[4].Color == PieceColor.White);
            Assert.That(b.Array[5] is Bishop && b.Array[5].Color == PieceColor.White);
            Assert.That(b.Array[6] is Knight && b.Array[6].Color == PieceColor.White);
            Assert.That(b.Array[7] is Rook && b.Array[7].Color == PieceColor.White);

            // Rank 2
            Assert.That(b.Array[16] is Pawn && b.Array[16].Color == PieceColor.White);
            Assert.That(b.Array[17] is Pawn && b.Array[17].Color == PieceColor.White);
            Assert.That(b.Array[18] is Pawn && b.Array[18].Color == PieceColor.White);
            Assert.That(b.Array[19] is Pawn && b.Array[19].Color == PieceColor.White);
            Assert.That(b.Array[20] is Pawn && b.Array[20].Color == PieceColor.White);
            Assert.That(b.Array[21] is Pawn && b.Array[21].Color == PieceColor.White);
            Assert.That(b.Array[22] is Pawn && b.Array[22].Color == PieceColor.White);
            Assert.That(b.Array[23] is Pawn && b.Array[23].Color == PieceColor.White);

            // Rank 3
            Assert.That(b.Array[32] == null);
            Assert.That(b.Array[33] == null);
            Assert.That(b.Array[34] == null);
            Assert.That(b.Array[35] == null);
            Assert.That(b.Array[36] == null);
            Assert.That(b.Array[37] == null);
            Assert.That(b.Array[38] == null);
            Assert.That(b.Array[39] == null);

            // Rank 4
            Assert.That(b.Array[48] == null);
            Assert.That(b.Array[49] == null);
            Assert.That(b.Array[50] == null);
            Assert.That(b.Array[51] == null);
            Assert.That(b.Array[52] == null);
            Assert.That(b.Array[53] == null);
            Assert.That(b.Array[54] == null);
            Assert.That(b.Array[55] == null);

            // Rank 5
            Assert.That(b.Array[64] == null);
            Assert.That(b.Array[65] == null);
            Assert.That(b.Array[66] == null);
            Assert.That(b.Array[67] == null);
            Assert.That(b.Array[68] == null);
            Assert.That(b.Array[69] == null);
            Assert.That(b.Array[70] == null);
            Assert.That(b.Array[71] == null);

            // Rank 6
            Assert.That(b.Array[80] == null);
            Assert.That(b.Array[81] == null);
            Assert.That(b.Array[82] == null);
            Assert.That(b.Array[83] == null);
            Assert.That(b.Array[84] == null);
            Assert.That(b.Array[85] == null);
            Assert.That(b.Array[86] == null);
            Assert.That(b.Array[87] == null);

            // Rank 7
            Assert.That(b.Array[96] is Pawn && b.Array[96].Color == PieceColor.Black);
            Assert.That(b.Array[97] is Pawn && b.Array[97].Color == PieceColor.Black);
            Assert.That(b.Array[98] is Pawn && b.Array[98].Color == PieceColor.Black);
            Assert.That(b.Array[99] is Pawn && b.Array[99].Color == PieceColor.Black);
            Assert.That(b.Array[100] is Pawn && b.Array[100].Color == PieceColor.Black);
            Assert.That(b.Array[101] is Pawn && b.Array[101].Color == PieceColor.Black);
            Assert.That(b.Array[102] is Pawn && b.Array[102].Color == PieceColor.Black);
            Assert.That(b.Array[103] is Pawn && b.Array[103].Color == PieceColor.Black);

            // Rank 8
            Assert.That(b.Array[112] is Rook && b.Array[112].Color == PieceColor.Black);
            Assert.That(b.Array[113] is Knight && b.Array[113].Color == PieceColor.Black);
            Assert.That(b.Array[114] is Bishop && b.Array[114].Color == PieceColor.Black);
            Assert.That(b.Array[115] is Queen && b.Array[115].Color == PieceColor.Black);
            Assert.That(b.Array[116] is King && b.Array[116].Color == PieceColor.Black);
            Assert.That(b.Array[117] is Bishop && b.Array[117].Color == PieceColor.Black);
            Assert.That(b.Array[118] is Knight && b.Array[118].Color == PieceColor.Black);
            Assert.That(b.Array[119] is Rook && b.Array[119].Color == PieceColor.Black);
        }

        [Test]
        public void Create_WhenCalledWithPosition_ShouldCreateBoardWithPosition()
        {
            var f = this.fenFactory.Create("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1");
            var b = this.boardFactory.Create(f);

            // Rank 1
            Assert.That(b.Array[0] is Rook && b.Array[0].Color == PieceColor.White);
            Assert.That(b.Array[1] is Knight && b.Array[1].Color == PieceColor.White);
            Assert.That(b.Array[2] is Bishop && b.Array[2].Color == PieceColor.White);
            Assert.That(b.Array[3] is Queen && b.Array[3].Color == PieceColor.White);
            Assert.That(b.Array[4] is King && b.Array[4].Color == PieceColor.White);
            Assert.That(b.Array[5] is Bishop && b.Array[5].Color == PieceColor.White);
            Assert.That(b.Array[6] is Knight && b.Array[6].Color == PieceColor.White);
            Assert.That(b.Array[7] is Rook && b.Array[7].Color == PieceColor.White);

            // Rank 2
            Assert.That(b.Array[16] is Pawn && b.Array[16].Color == PieceColor.White);
            Assert.That(b.Array[17] is Pawn && b.Array[17].Color == PieceColor.White);
            Assert.That(b.Array[18] is Pawn && b.Array[18].Color == PieceColor.White);
            Assert.That(b.Array[19] is Pawn && b.Array[19].Color == PieceColor.White);
            Assert.That(b.Array[20] == null);
            Assert.That(b.Array[21] is Pawn && b.Array[21].Color == PieceColor.White);
            Assert.That(b.Array[22] is Pawn && b.Array[22].Color == PieceColor.White);
            Assert.That(b.Array[23] is Pawn && b.Array[23].Color == PieceColor.White);

            // Rank 3
            Assert.That(b.Array[32] == null);
            Assert.That(b.Array[33] == null);
            Assert.That(b.Array[34] == null);
            Assert.That(b.Array[35] == null);
            Assert.That(b.Array[36] == null);
            Assert.That(b.Array[37] == null);
            Assert.That(b.Array[38] == null);
            Assert.That(b.Array[39] == null);

            // Rank 4
            Assert.That(b.Array[48] == null);
            Assert.That(b.Array[49] == null);
            Assert.That(b.Array[50] == null);
            Assert.That(b.Array[51] == null);
            Assert.That(b.Array[52] is Pawn && b.Array[52].Color == PieceColor.White);
            Assert.That(b.Array[53] == null);
            Assert.That(b.Array[54] == null);
            Assert.That(b.Array[55] == null);

            // Rank 5
            Assert.That(b.Array[64] == null);
            Assert.That(b.Array[65] == null);
            Assert.That(b.Array[66] == null);
            Assert.That(b.Array[67] == null);
            Assert.That(b.Array[68] == null);
            Assert.That(b.Array[69] == null);
            Assert.That(b.Array[70] == null);
            Assert.That(b.Array[71] == null);

            // Rank 6
            Assert.That(b.Array[80] == null);
            Assert.That(b.Array[81] == null);
            Assert.That(b.Array[82] == null);
            Assert.That(b.Array[83] == null);
            Assert.That(b.Array[84] == null);
            Assert.That(b.Array[85] == null);
            Assert.That(b.Array[86] == null);
            Assert.That(b.Array[87] == null);

            // Rank 7
            Assert.That(b.Array[96] is Pawn && b.Array[96].Color == PieceColor.Black);
            Assert.That(b.Array[97] is Pawn && b.Array[97].Color == PieceColor.Black);
            Assert.That(b.Array[98] is Pawn && b.Array[98].Color == PieceColor.Black);
            Assert.That(b.Array[99] is Pawn && b.Array[99].Color == PieceColor.Black);
            Assert.That(b.Array[100] is Pawn && b.Array[100].Color == PieceColor.Black);
            Assert.That(b.Array[101] is Pawn && b.Array[101].Color == PieceColor.Black);
            Assert.That(b.Array[102] is Pawn && b.Array[102].Color == PieceColor.Black);
            Assert.That(b.Array[103] is Pawn && b.Array[103].Color == PieceColor.Black);

            // Rank 8
            Assert.That(b.Array[112] is Rook && b.Array[112].Color == PieceColor.Black);
            Assert.That(b.Array[113] is Knight && b.Array[113].Color == PieceColor.Black);
            Assert.That(b.Array[114] is Bishop && b.Array[114].Color == PieceColor.Black);
            Assert.That(b.Array[115] is Queen && b.Array[115].Color == PieceColor.Black);
            Assert.That(b.Array[116] is King && b.Array[116].Color == PieceColor.Black);
            Assert.That(b.Array[117] is Bishop && b.Array[117].Color == PieceColor.Black);
            Assert.That(b.Array[118] is Knight && b.Array[118].Color == PieceColor.Black);
            Assert.That(b.Array[119] is Rook && b.Array[119].Color == PieceColor.Black);
        }
    }
}