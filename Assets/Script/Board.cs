using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	private Player whitePlayer;
	private Player blackPlayer;

	public bool whiteCheck;
	public bool blackCheck;

	// Constructors

	public Board () {
		InitializeSquares ();
	}

	public Board (Board b, Move m) {
		InitializeSquares ();
	//	b.pieces. .SetPosition (m.movePoisition);
	}

	public Board (string[] b) {
		InitializeSquares ();
		for (int j = 0; j < 8; j++) {
			for (int i = 0; i < 8; i++) {
				switch (b [j] [i]) {
					case 'r':
						pieces.Add (new Rook (i, j, false));
						break;
					case 'n':
						pieces.Add (new Knight (i, j, false));
						break;
					case 'b':
						pieces.Add (new Bishop (i, j, false));
						break;
					case 'q':
						pieces.Add (new Queen (i, j, false));
						break;
					case 'k':
						pieces.Add (new King (i, j, false));
						break;
					case 'p':
						pieces.Add (new Pawn (i, j, false));
						break;
					case 'R':
						pieces.Add (new Rook (i, j, true));
						break;
					case 'N':
						pieces.Add (new Knight (i, j, true));
						break;
					case 'B':
						pieces.Add (new Bishop (i, j, true));
						break;
					case 'Q':
						pieces.Add (new Queen (i, j, true));
						break;
					case 'K':
						pieces.Add (new King (i, j, true));
						break;
					case 'P':
						pieces.Add (new Pawn (i, j, true));
						break;
					case 'E':
						break;	
				}
			}
		}
	}

	private void InitializeSquares(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				squares [j, i] = new Square (j, i);
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

//	public Square GetUpper(Square sq){
//		return squares [sq.GetColumn(), sq.GetRow() + 1];
//	}
//
//	public Square GetLower(Square sq){
//		return squares [sq.GetColumn(), sq.GetRow() - 1];
//	}
//
//	public Square GetRight(Square sq){
//		return squares [sq.GetColumn() + 1, sq.GetRow()];
//	}
//
//	public Square GetLeft(Square sq){
//		return squares [sq.GetColumn() - 1, sq.GetRow()];
//	}
//
//	public Square GetUpperLeft(Square sq){
//		return squares [sq.GetColumn() - 1, sq.GetRow() + 1];
//	}
//
//	public Square GetLowerLeft(Square sq){
//		return squares [sq.GetColumn() - 1, sq.GetRow() - 1];
//	}
//
//	public Square GetUpperRight(Square sq){
//		return squares [sq.GetColumn() + 1, sq.GetRow() + 1];
//	}
//
//	public Square GetLowerRight(Square sq){
//		return squares [sq.GetColumn() + 1, sq.GetRow() - 1];
//	}
//
//	public Square GetSquare(int c, int r){
//		return squares [c, r];
//	}
//
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