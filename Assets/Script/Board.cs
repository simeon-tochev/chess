using System.Collections;
using System.Collections.Generic;


public class Board {

    public static readonly Board STARTING_BOARD = new Board(
        new string[]{   "rnbqkbnr",
                        "pppppppp",
                        "EEEEEEEE",
                        "EEEEEEEE",
                        "EEEEEEEE",
                        "EEEEEEEE",
                        "PPPPPPPP",
                        "RNBQKBNR",
                    }, false
	);
		
	public Square[,] squares = new Square[8,8];

    public List<Piece> pieces = new List<Piece>();

    public Move lastMove;

    /*
	public List<Piece> blackPieces = new List<Piece>();
    public List<Piece> whitePieces = new List<Piece>();
    */

    /*
	public Player whitePlayer = new Player(false);
	public Player blackPlayer = new Player(true);
    */

    public bool blackToPlay;

    public List<Move> legalMoves;

	// Constructors

	public Board () {
		InitializeSquares ();
		CalculateMoves ();
	}

    public Board(Board b) {
        squares = b.squares;
        pieces = b.pieces;
        lastMove = b.lastMove;
        blackToPlay = b.blackToPlay;
        legalMoves = b.legalMoves;
    }

	public Board (Board b, Move m) {

		squares = b.squares;
        pieces = b.pieces;
        blackToPlay = !b.blackToPlay;
	//	pieces.Find (p => p.Equals (m.pieceToMove)).SetPosition (m.movePoisition);
    //    m.pi
	//	CalculateMoves ();
	//	b.pieces. .SetPosition (m.movePoisition);
	}

    public Board(string[] b, bool blackToPlay) {
		InitializeSquares ();
		for (char i = '1'; i < '9'; i++)  {
			for (char j = 'A'; j < 'I'; j++) {
				switch (b [i - '1'][j - 'A'] ) {
					case 'r':
						pieces.Add (new Rook (j, i, false, this));
						break;
					case 'n':
						pieces.Add (new Knight (j, i, false, this));
						break;
					case 'b':
						pieces.Add (new Bishop (j, i, false, this));
						break;
					case 'q':
						pieces.Add (new Queen (j, i, false, this));
						break;
					case 'k':
						pieces.Add (new King (j, i, false, this));
						break;
					case 'p':
						pieces.Add (new Pawn (j, i, false, this));
						break;
					case 'R':
						pieces.Add (new Rook (j, i, true, this));
						break;
					case 'N':
						pieces.Add (new Knight (j, i, true, this));
						break;
					case 'B':
						pieces.Add (new Bishop (j, i, true, this));
						break;
					case 'Q':
						pieces.Add (new Queen (j, i, true, this));
						break;
					case 'K':
						pieces.Add (new King (j, i, true, this));
						break;
					case 'P':
						pieces.Add (new Pawn (j, i, true, this));
						break;
					case 'E':
						break;	
				}
			}
		}

        lastMove = Move.EMPTY_MOVE;
        this.blackToPlay = blackToPlay;

        CalculateLegalMoves();
	}

	private void InitializeSquares(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				squares [j, i] = new Square (j, i, this);
			}
		}
	}

	// Methods

    /// TODO:
    ///  FIGURE OUT HOW TO IMPLEMENT CHECKING

	public void CalculateMoves(){
        legalMoves = new List<Move>();
        foreach (Piece p in pieces) {
            if (p.color == blackToPlay) {
                legalMoves.AddRange(p.CalculateLegalMoves());
            }
        }
	}

    public void CalculateLegalMoves() {
        CalculateMoves();
        List<Move> newLegalMoves = new List<Move>();
        foreach (Move m in legalMoves) {
            Board b = new Board(this);
            b.MakeMoveEmptyMoves(m);
            if (b.IsChecked(blackToPlay)) {
                newLegalMoves.Add(m);
            }
        }
        legalMoves = newLegalMoves;
    }

	public Square GetUpper(Square sq){
		return squares [sq.col - 'A', sq.row - '1' + 1];
	}

	public Square GetLower(Square sq){
		return squares [sq.col - 'A', sq.row - '1' - 1];
	}

	public Square GetRight(Square sq){
		return squares [sq.col - 'A' + 1, sq.row - '1'];
	}

	public Square GetLeft(Square sq){
		return squares [sq.col - 'A' - 1, sq.row - '1'];
	}
    
	public Square GetUpperLeft(Square sq){
		return squares [sq.col - 'A' - 1, sq.row - '1' + 1];
	}

	public Square GetLowerLeft(Square sq){
		return squares [sq.col - 'A' - 1, sq.row - '1' - 1];
	}

	public Square GetUpperRight(Square sq){
		return squares [sq.col - 'A' + 1, sq.row - '1' + 1];
	}

	public Square GetLowerRight(Square sq){
		return squares [sq.col - 'A' + 1, sq.row - '1' - 1];
	}

	public Square GetSquare(int c, int r){
		return squares [c, r];
	}

    public void MakeMoveEmptyMoves(Move m) {
                legalMoves.Clear();
        if (m.castleMove) {
            if (m.castle == 1) {
                if (m.blackTurn) {
                    pieces.Find(p => p.pieceName.Equals("King_Black")).SetPosition(squares[6, 7]);
                    pieces.Find(p => p.pieceName.Equals("Rook_Black")).SetPosition(squares[5, 7]);
                }
                else {
                    pieces.Find(p => p.pieceName.Equals("King_White")).SetPosition(squares[6, 0]);
                    pieces.Find(p => p.pieceName.Equals("Rook_White")).SetPosition(squares[5, 0]);
                }
            }
            else {
                if (m.blackTurn) {
                    pieces.Find(p => p.pieceName.Equals("King_Black")).SetPosition(squares[2, 7]);
                    pieces.Find(p => p.pieceName.Equals("Rook_Black")).SetPosition(squares[3, 7]);
                }
                else {
                    pieces.Find(p => p.pieceName.Equals("King_White")).SetPosition(squares[2, 0]);
                    pieces.Find(p => p.pieceName.Equals("Rook_White")).SetPosition(squares[3, 0]);
                }
            }
            return;
        }

        pieces.Find(p => p.Equals(m.pieceToMove)).SetPosition(m.movePoisition);
        if (m.takeMove) {
            pieces.Remove(m.pieceToTake);
        }


    }

    public void MakeMove(Move m) {
        MakeMoveEmptyMoves(m);
        CalculateLegalMoves();

    }

    public Board GetNextBoard(Move m) {
        Board b = new Board(this);
        b.MakeMove(m);
        return b;
    }

    public List<Board> GetNextBoards() {
        return null;
    }

    public bool IsChecked(bool kingColor) {
        if (kingColor) {
            foreach (Move m in legalMoves) {
                if (m.pieceToTake.pieceName.Equals("King_Black")) {
                    return true;
                }
                
            }
        } else {
            foreach (Move m in legalMoves) {
                if (m.pieceToTake.pieceName.Equals("King_White")) {
                    return true;
                }
            }
        }
        return false;
    }

//	public Square GetSquare(string pos){
//		int c = (int)(pos [0] - 'A');
//		int r = (int)(pos [1] - '1');
//		return squares [c, r];
//	}
//
//	public Square[,] GetSquares(){
//		return squares;	
//	}
//		
}