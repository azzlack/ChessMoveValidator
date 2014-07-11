namespace ChessMoveValidator.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ChessMoveValidator.Core.Enums;
    using ChessMoveValidator.Core.Interfaces.Models;
    using ChessMoveValidator.Core.Models.Pieces;

    /// <summary>
    /// Represents a chess board using <a href="http://chessprogramming.wikispaces.com/0x88">0x88 representation</a>.
    /// </summary>
    /// <example>
    ///   Square indexes:
    ///   + ------------------------------- + ------------------------------- +
    ///   | 112 113 114 115 116 117 118 119 | 120 121 122 123 124 125 126 127 |
    ///   | 96  97  98  99  100 101 102 103 | 104 105 106 107 108 109 110 111 |
    /// R | 80  81  82  83  84  85  86  87  | 88  89  90  91  92  93  94  95  |
    /// A | 64  65  66  67  68  69  70  71  | 72  73  74  75  76  77  78  79  |
    /// N | 48  49  50  51  52  53  54  55  | 56  57  58  59  60  61  62  63  |
    /// K | 32  33  34  35  36  37  38  39  | 40  41  42  43  44  45  46  47  |
    ///   | 16  17  18  19  20  21  22  23  | 24  25  26  27  28  29  30  31  |
    ///   | 0   1   2   3   4   5   6   7   | 8   9   10  11  12  13  14  15  |
    ///   + ------------------------------- + ------------------------------- +
    ///                F I L E
    ///   Starting layout:
    ///   + ------------------------------- + ------------------------------- +
    ///   | r   n   b   q   k   b   n   r   | .   .   .   .   .   .   .   .   |
    ///   | p   p   p   p   p   p   p   p   | .   .   .   .   .   .   .   .   |
    /// R | .   .   .   .   .   .   .   .   | .   .   .   .   .   .   .   .   |
    /// A | .   .   .   .   .   .   .   .   | .   .   .   .   .   .   .   .   |
    /// N | .   .   .   .   .   .   .   .   | .   .   .   .   .   .   .   .   |
    /// K | .   .   .   .   .   .   .   .   | .   .   .   .   .   .   .   .   |
    ///   | P   P   P   P   P   P   P   P   | .   .   .   .   .   .   .   .   |
    ///   | R   N   B   Q   K   B   N   R   | .   .   .   .   .   .   .   .   |
    ///   + ------------------------------- + ------------------------------- +
    ///                F I L E
    /// </example>
    public class Board : IBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board()
        {
            this.Settings = new BoardSettings();
           
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown if no settings were supplied.</exception>
        public Board(BoardSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this.Settings = settings;
            
            this.Initialize();
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public BoardSettings Settings { get; private set; }

        /// <summary>
        /// Gets the board array.
        /// </summary>
        /// <value>The board array.</value>
        public IPiece[] Array { get; private set; }

        /// <summary>
        /// Gets the black pieces.
        /// </summary>
        /// <value>The black pieces.</value>
        public IEnumerable<IPiece> BlackPieces
        {
            get
            {
                return this.Array.Where(x => x != null && x.Color == PieceColor.Black);
            }
        }

        /// <summary>
        /// Gets the white pieces.
        /// </summary>
        /// <value>The white pieces.</value>
        public IEnumerable<IPiece> WhitePieces
        {
            get
            {
                return this.Array.Where(x => x != null && x.Color == PieceColor.White);
            }
        }

        /// <summary>
        /// Gets the black king.
        /// </summary>
        /// <value>The black king.</value>
        public ICheckable BlackKing
        {
            get
            {
                return (ICheckable)this.Array.SingleOrDefault(x => x is King && x.Color == PieceColor.Black);
            }
        }

        /// <summary>
        /// Gets the white king.
        /// </summary>
        /// <value>The white king.</value>
        public ICheckable WhiteKing
        {
            get
            {
                return (ICheckable)this.Array.SingleOrDefault(x => x is King && x.Color == PieceColor.White);
            }
        }

        /// <summary>
        /// Gets or sets the side to move.
        /// </summary>
        /// <value>The side to move.</value>
        public PieceColor SideToMove { get; set; }

        /// <summary>
        /// Gets or sets the castling availability.
        /// </summary>
        /// <value>The castling availability.</value>
        public CastlingAvailability CastlingAvailability { get; set; }

        /// <summary>
        /// Gets or sets the index of the en passant square.
        /// </summary>
        /// <value>The index of the en passant square.</value>
        public int EnPassantSquareIndex { get; set; }

        /// <summary>
        /// Gets or sets a decimal number of half moves with respect to the 50 move draw rule.
        /// </summary>
        /// <value>The number of half moves.</value>
        /// <remarks>It is reset to zero after a capture or a pawn move and incremented otherwise.</remarks>
        public int NumberOfHalfMoves { get; set; }

        /// <summary>
        /// Gets or sets the number of the full moves in the game.
        /// </summary>
        /// <value>The number of moves.</value>
        /// <remarks>It starts at 1, and is incremented after each Black's move.</remarks>
        public int NumberOfRounds { get; set; }

        /// <summary>
        /// Gets or sets the current piece/square Zobrist hash key.
        /// </summary>
        /// <value>The current piece/square hash key.</value>
        public ulong CurrentHashKey { get; set; }

        /// <summary>
        /// Gets or sets the hash keys for castling.
        /// </summary>
        /// <value>The hash keys for castling.</value>
        public ulong[] HashKeysForCastling { get; set; }

        /// <summary>
        /// Gets or sets the hash keys for en passant.
        /// </summary>
        /// <value>The hash keys for en passant.</value>
        public ulong[] HashKeysForEnPassant { get; set; }

        /// <summary>
        /// Initializes the board with default values.
        /// </summary>
        public void Initialize()
        {
            this.Array = new IPiece[128];
            this.CurrentHashKey = 0;
            this.HashKeysForCastling = new ulong[16];
            this.HashKeysForEnPassant = new ulong[8];

            this.CastlingAvailability = CastlingAvailability.None;
        }
    }
}