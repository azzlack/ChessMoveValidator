namespace ChessMoveValidator.BusinessLogic.Factories
{
    using System.Linq;

    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Factories;
    using ChessMoveValidator.Core.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Factory for creating FEN objects from string notations.
    /// </summary>
    public class FenFactory : IFenFactory
    {
        /// <summary>
        /// Creates a FEN representation with default positions.
        /// </summary>
        /// <returns>A FEN representation.</returns>
        public Fen Create()
        {
            return this.Create("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        }

        /// <summary>
        /// Creates a FEN object from the specified string.
        /// </summary>
        /// <param name="fenPosition">The FEN strings.</param>
        /// <returns>A FEN object.</returns>
        public Fen Create(string fenPosition)
        {
            var fen = new Fen();

            var parameters = fenPosition.Split(' ');

            var rows = parameters[0].Split('/');

            // 1. Parse piece placement
            for (var i = 0; i < rows.Length; i++)
            {
                // Ranks in FEN notation is in big-endian order, meaning it starts with black's end seen from white's perspective
                var row = rows[i];
                var rank = rows.Length - 1 - i;

                // Files in FEN notation is in little-endian order, meaning it goes from left to right
                for (var j = 0; j < row.Length; j++)
                {
                    var piece = row[j];
                    var file = fen.Board.Count(x => x.Rank == rank);

                    if (piece == 'r')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Rook(PieceColor.Black)
                                });
                    }
                    else if (piece == 'n')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Knight(PieceColor.Black)
                                });
                    }
                    else if (piece == 'b')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece = new Bishop(PieceColor.Black)
                                });
                    }
                    else if (piece == 'q')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Queen(PieceColor.Black)
                                });
                    }
                    else if (piece == 'k')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new King(PieceColor.Black)
                                });
                    }
                    else if (piece == 'p')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Pawn(PieceColor.Black)
                                });
                    }
                    else if (piece == 'R')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Rook(PieceColor.White)
                                });
                    }
                    else if (piece == 'N')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Knight(PieceColor.White)
                                });
                    }
                    else if (piece == 'B')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Bishop(PieceColor.White)
                                });
                    }
                    else if (piece == 'Q')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Queen(PieceColor.White)
                                });
                    }
                    else if (piece == 'K')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new King(PieceColor.White)
                                });
                    }
                    else if (piece == 'P')
                    {
                        fen.Board.Add(
                            new Square(rank, file)
                                {
                                    Piece =
                                        new Pawn(PieceColor.White)
                                });
                    }
                    else if (piece == '1')
                    {
                        fen.Board.Add(new Square(rank, file));
                    }
                    else if (piece == '2')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                    }
                    else if (piece == '3')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                    }
                    else if (piece == '4')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                        fen.Board.Add(new Square(rank, file + 3));
                    }
                    else if (piece == '5')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                        fen.Board.Add(new Square(rank, file + 3));
                        fen.Board.Add(new Square(rank, file + 4));
                    }
                    else if (piece == '6')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                        fen.Board.Add(new Square(rank, file + 3));
                        fen.Board.Add(new Square(rank, file + 4));
                        fen.Board.Add(new Square(rank, file + 5));
                    }
                    else if (piece == '7')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                        fen.Board.Add(new Square(rank, file + 3));
                        fen.Board.Add(new Square(rank, file + 4));
                        fen.Board.Add(new Square(rank, file + 5));
                        fen.Board.Add(new Square(rank, file + 6));
                    }
                    else if (piece == '8')
                    {
                        fen.Board.Add(new Square(rank, file));
                        fen.Board.Add(new Square(rank, file + 1));
                        fen.Board.Add(new Square(rank, file + 2));
                        fen.Board.Add(new Square(rank, file + 3));
                        fen.Board.Add(new Square(rank, file + 4));
                        fen.Board.Add(new Square(rank, file + 5));
                        fen.Board.Add(new Square(rank, file + 6));
                        fen.Board.Add(new Square(rank, file + 7));
                    }
                }
            }

            // 2. Parse side to move
            fen.SideToMove = parameters[1] == "w" ? PieceColor.White : PieceColor.Black;

            // 3.Parse castling rigts
            foreach (var castlingRight in parameters[2])
            {
                switch (castlingRight)
                {
                    case 'K':
                        fen.CastlingRights |= CastlingAvailability.KingSideWhite;
                        break;
                    case 'Q':
                        fen.CastlingRights |= CastlingAvailability.QueenSideWhite;
                        break;
                    case 'k':
                        fen.CastlingRights |= CastlingAvailability.KingSideBlack;
                        break;
                    case 'q':
                        fen.CastlingRights |= CastlingAvailability.QueenSideBlack;
                        break;
                }
            }

            // 4. Parse en passant sqaure
            if (parameters[3] != "-")
            {
                var file = "abcdefgh".IndexOf(parameters[3][0].ToString().ToLower());
                var rank = int.Parse(parameters[3][1].ToString()) - 1;

                fen.EnPassantSquare = new Square(rank, file);
            }

            // 5. Parse halfmove clock
            fen.HalfmoveClock = int.Parse(parameters[4]);

            // 6. Parse fullmove counter
            fen.FullmoveCounter = int.Parse(parameters[5]);

            return fen;
        }
    }
}