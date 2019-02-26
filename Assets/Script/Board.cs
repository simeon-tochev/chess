using System.Collections;
using System.Collections.Generic;


public class Board {

	public static readonly Board STARTING_BOARD = new Board( 
		new string[]{	"rnbqkbnr",
						"pppppppp",
						"EEEEEEEE",
						"EEEEEEEE",
						"EEEEEEEE",
						"EEEEEEEE",
						"PPPPPPPP",
						"RNBQKBNR",
					}
	);
		
	public Square[,] squares = new Square[8,8];

	public List<Piece> pieces = new List<Piece>();

	public Player whitePlayer = new Player(false);
	public Player blackPlayer = new Player(true);

	// Constructors

	public Board () {
		InitializeSquares ();
	//	CalculateMoves ();
	}

	public Board (Board b, Move m) {
	// TODO: This is not a constructor :(
	// ???
		this.squares = b.squares;
		this.pieces = b.pieces;
		this.whitePlayer = b.whitePlayer;
		this.blackPlayer = b.blackPlayer;
		pieces.Find (p => p.Equals (m.pieceToMove)).SetPosition (m.movePoisition);
		CalculateMoves ();
	//	b.pieces. .SetPosition (m.movePoisition);
	}

	public Board (string[] b) {
		InitializeSquares ();
		for (int j = 0; j < 8; j++) {
			for (int i = 0; i < 8; i++) {
				switch (b [j] [i]) {
					case 'r':
						pieces.Add (new Rook (i, j, false, this));
						break;
					case 'n':
						pieces.Add (new Knight (i, j, false, this));
						break;
					case 'b':
						pieces.Add (new Bishop (i, j, false, this));
						break;
					case 'q':
						pieces.Add (new Queen (i, j, false, this));
						break;
					case 'k':
						pieces.Add (new King (i, j, false, this));
						break;
					case 'p':
						pieces.Add (new Pawn (i, j, false, this));
						break;
					case 'R':
						pieces.Add (new Rook (i, j, true, this));
						break;
					case 'N':
						pieces.Add (new Knight (i, j, true, this));
						break;
					case 'B':
						pieces.Add (new Bishop (i, j, true, this));
						break;
					case 'Q':
						pieces.Add (new Queen (i, j, true, this));
						break;
					case 'K':
						pieces.Add (new King (i, j, true, this));
						break;
					case 'P':
						pieces.Add (new Pawn (i, j, true, this));
						break;
					case 'E':
						break;	
				}
			}
		}
        
		// CalculateMoves ();
	}

	private void InitializeSquares(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				squares [j, i] = new Square (j, i, this);
			}
		}
	}

	// Methods

	public void CalculateMoves(){
		whitePlayer.ClearLegalMoves ();
		blackPlayer.ClearLegalMoves ();
		foreach (Piece p in pieces) {
			p.CalculateLegalMoves ();
		}
		whitePlayer.AddLegalMoves ();
		blackPlayer.AddLegalMoves ();
	}

	public bool Checked(bool color){
		CalculateMoves ();
		if (color) {
			return BlackChecked ();
		} else {
			return WhiteChecked ();
		}
	}

	public bool WhiteChecked(){
        return false; 
	}

	public bool BlackChecked(){
        return false;
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