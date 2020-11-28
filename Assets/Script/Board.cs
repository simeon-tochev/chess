using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


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

    public static readonly Board TEST_BOARD = new Board(
        new string[]{   "rnbqkbnr",
                        "EEEEEEEE",
                        "EEEEEEEE",
                        "EEEEEEEE",
                        "EEEEEEpE",
                        "EEEEEEEE",
                        "EEEEEPEE",
                        "RNBQKEEE",
                    }, false

    );
		
	public Square[,] squares = new Square[8,8];

    public List<Piece> pieces = new List<Piece>();

 //   public Move lastMove;

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

    public char gameState = '1'; // 1 - Game on, 2 - Black CheckMated, 3 - White CheckMated, 4 - Black Resigned, 5 - White Resigned, 6 - White StaleMated, 7 - Black Stalemated, 8 - Draw

	// Constructors

	public Board () {
		InitializeSquares ();
		CalculateMoves ();
	}

    public Board(Board b) {
        InitializeSquares();
        pieces = new List<Piece>();
        
        foreach (Piece p in b.pieces) {
            pieces.Add(p.Clone(this));
        }

        blackToPlay = b.blackToPlay;
        legalMoves = new List<Move>();
    }

    /*
	public Board (Board b, Move m) {
        /// To fix
		squares = b.squares;
        pieces = b.pieces;
        blackToPlay = !b.blackToPlay;
	//	pieces.Find (p => p.Equals (m.pieceToMove)).SetPosition (m.movePoisition);
    //    m.pi
	//	CalculateMoves ();
	//	b.pieces. .SetPosition (m.movePoisition);
	}
    */

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

     //   lastMove = Move.EMPTY_MOVE;
        this.blackToPlay = blackToPlay;

     //   CalculateMoves();
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
        if (KCastleCheck(blackToPlay)) {
            legalMoves.Add(new Move(blackToPlay, 1));
        }
        if (QCastleCheck(blackToPlay)) {
            legalMoves.Add(new Move(blackToPlay, 2));
        }
    }

    public List<Move> GetMoves(bool c) {
        List<Move> moves = new List<Move>();
        foreach (Piece p in pieces) {
            if (p.color == c) {
                moves.AddRange(p.CalculateLegalMoves());
            }
        }
        return moves;
    }

    public void CalculateLegalMoves() {
        CalculateMoves();
        List<Move> newLegalMoves = new List<Move>();
        foreach (Move m in legalMoves) {
            Board b = new Board(this);
            b.MakeMoveEmptyMoves(m);
            b.CalculateMoves();
            if (!b.IsChecked(blackToPlay)) {
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


    /// To Fix with chars eventually..
    /// 

	public Square GetSquare(int c, int r){
		return squares [c, r];
	}

    public void MakeMoveEmptyMoves(Move m) {
        if (m.castleMove) {
            if (m.castle == 1) {
                if (m.blackTurn) {
                    pieces.Find(p => p.pieceName.Equals("King_Black")).SetPosition(squares[6, 7]);
                    pieces.Find(p => p.pieceName.Equals("Rook_Black") && p.col == 'H').SetPosition(squares[5, 7]);
                    squares[7, 7].occupant = null;
                    squares[4, 7].occupant = null;
                }
                else {
                    pieces.Find(p => p.pieceName.Equals("King_White")).SetPosition(squares[6, 0]);
                    pieces.Find(p => p.pieceName.Equals("Rook_White") && p.col == 'H').SetPosition(squares[5, 0]);
                    squares[7, 0].occupant = null;
                    squares[4, 0].occupant = null;
                }
            }
            else {
                if (m.blackTurn) {
                    pieces.Find(p => p.pieceName.Equals("King_Black")).SetPosition(squares[2, 7]);
                    pieces.Find(p => p.pieceName.Equals("Rook_Black") && p.col == 'A').SetPosition(squares[3, 7]);
                    squares[0, 7].occupant = null;
                    squares[4, 7].occupant = null;
                }
                else {
                    pieces.Find(p => p.pieceName.Equals("King_White")).SetPosition(squares[2, 0]);
                    pieces.Find(p => p.pieceName.Equals("Rook_White") && p.col == 'A').SetPosition(squares[3, 0]);
                    squares[0, 0].occupant = null;
                    squares[4, 0].occupant = null;
                }
            }
            blackToPlay = !blackToPlay;
            return;
        }

        if (m.takeMove) {
            pieces.Remove(FindPieceOnBoard(m.colTo, m.rowTo));
        } else if (m.enPassant) {
        //    Debug.Log("En Passant");
            if (blackToPlay) {
                pieces.Remove(FindPieceOnBoard(m.colTo, '4'));
            } else {
      //          Debug.Log("Removing " + FindPieceOnBoard(m.colTo, '5').pieceName);
                pieces.Remove(FindPieceOnBoard(m.colTo, '5'));
            }

        }
        Piece pieceToMove = FindPieceOnBoard(m.colFrom, m.rowFrom);
        pieceToMove.SetPosition(m.colTo, m.rowTo);
        pieceToMove.hasMoved = true;
        GetSquare(m.colFrom - 'A', m.rowFrom - '1').occupant = null;

        if (m.promoteMove) {
            int index = pieces.IndexOf(pieceToMove);
            switch (m.promoteTo) {
                case 1: pieces[index] = new Queen(pieceToMove, this); break;
                case 2: pieces[index] = new Rook(pieceToMove, this); break;
                case 3: pieces[index] = new Bishop(pieceToMove, this); break;
                case 4: pieces[index] = new Knight(pieceToMove, this); break;
            }
        }

        foreach(Piece p in pieces) {
            if(p.GetType().Name == "Pawn" && pieceToMove == p && Mathf.Abs(m.rowTo - m.rowFrom) == 2) {
                p.enPassant = true;
             //   Debug.Log(p.pieceName + " enPassant");
            } else {
                p.enPassant = false;
            }
        }

        blackToPlay = !blackToPlay;

    }

    public void MakeMove(Move m) {
     //   Debug.Log("EnPassant Move: " + m.enPassant.ToString());
        MakeMoveEmptyMoves(m);
        CalculateLegalMoves();
        GameStateCheck();
    }

    public Board GetNextBoard(Move m) {
        Board b = new Board(this);
        b.MakeMove(m);
        return b;
    }

    public List<Board> GetNextBoards() {
        List<Board> nextBoards = new List<Board>();
        foreach(Move m in legalMoves) {
            nextBoards.Add(GetNextBoard(m));
        }
        return nextBoards;
    }

    public bool IsChecked(bool kingColor) {
        if (kingColor) {
            foreach (Move m in legalMoves) {
                if (m.takeMove) {
                    if (FindPieceOnBoard(m.colTo, m.rowTo).pieceName.Equals("King_Black")) {
                        return true;
                    }
                }
            }
        } else {
            foreach (Move m in legalMoves) {
                if (m.takeMove) {
                    if (FindPieceOnBoard(m.colTo, m.rowTo).pieceName.Equals("King_White")) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    

    public Piece FindPieceOnBoard(char col, char row) {
        return GetSquare(col - 'A', row - '1').GetOccupant();
    }

    public Square FindEquivalentSquare(Square s) {
        if(s == null) {
            return null;
        }
        return GetSquare(s.col - 'A', s.row - '1');
    }

    public string ToString() {
        string str = "";
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                str += squares[i, j].toString();
            }
            str += "\n";
        }
        return str;
    }

    public void GameStateCheck() {
        if(legalMoves.Count == 0) {
            if (blackToPlay) {
                Piece k = pieces.Find(p => p.pieceName == "King_Black");
                if (IsAttacked(k.position, false)){
                    gameState = '2';
                } else {
                    gameState = '6';
                }
            } else {
                Piece k = pieces.Find(p => p.pieceName == "King_White");
                if (IsAttacked(k.position, true)) {
                    gameState = '3';
                }
                else {
                    gameState = '7';
                }
            }
        }
    }


    /// Figure out a way to implement pawn attacking behaviour
    public bool IsAttacked(Square sq, bool color) {
        List<Move> moves = GetMoves(color);
        foreach(Move m in moves) {
            if(GetSquare(m.colTo - 'A', m.rowTo - '1') == sq){
                return true;
            }
        }
        return false;
    }

    public bool IsAttacked(Square sq, List<Move> moves) {
        foreach (Move m in moves) {
            if (GetSquare(m.colTo - 'A', m.rowTo - '1') == sq) {
                return true;
            }
        }
        return false;
    }

    public bool QCastleCheck(bool color) {
        Piece k = null;
        Piece r = null;
        if (color) {
            k = pieces.Find(p => p.pieceName == "King_Black");
            r = pieces.Find(p => p.col == 'A' && p.row == '8' && p.pieceName == "Rook_Black");
        } else {
            k = pieces.Find(p => p.pieceName == "King_White");
            r = pieces.Find(p => p.col == 'A' && p.row == '1' && p.pieceName == "Rook_White");
        }
        if (k == null || k.hasMoved ) { return false; }
        if (r == null || r.hasMoved) { return false; }
        if (k.position.GetLeft().isOccupied() || k.position.GetLeft().GetLeft().isOccupied() || k.position.GetLeft().GetLeft().GetLeft().isOccupied()) { return false; }
        if (IsAttacked(k.position, !color) || IsAttacked(k.position.GetLeft(), !color) || IsAttacked(k.position.GetLeft().GetLeft(), !color) || IsAttacked(k.position.GetLeft().GetLeft().GetLeft(), !color)) { return false; }
        return true;
    }

    public bool KCastleCheck (bool color) {
        Piece k = null;
        Piece r = null;
        if (color) {
            k = pieces.Find(p => p.pieceName == "King_Black");
            r = pieces.Find(p => p.col == 'H' && p.row == '8' && p.pieceName == "Rook_Black");
        }
        else {
            k = pieces.Find(p => p.pieceName == "King_White");
            r = pieces.Find(p => p.col == 'H' && p.row == '1' && p.pieceName == "Rook_White");
        }
        if (k == null || k.hasMoved) { return false; }
        if (r == null || r.hasMoved) { return false; }
        if (k.position.GetRight().isOccupied() || k.position.GetRight().GetRight().isOccupied()) { return false; }
        if (IsAttacked(k.position, !color) || IsAttacked(k.position.GetRight(), !color) || IsAttacked(k.position.GetRight().GetRight(), !color) ) { return false; }
        return true;
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