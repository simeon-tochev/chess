using System.Collections;
using System.Collections.Generic;

public abstract class Piece  {

	public string		pieceName;

	public char 		col;				//  Mimic the collumn and row						
	public char 		row;   				//	properties of the square

	public bool			color; 				// True for black

	public Square 		position;

//	public List<Move>	legalMoves = new List<Move> ();

	public MoveManager 	moveManager;

	public Board 		board;


	// Abstract Methods and Properties

	public abstract List<Move> CalculateLegalMoves();

	// Constructors

	public Piece(int col, int row, bool color, Board board){
		pieceName = GetType ().Name;
		if (color) {
			pieceName += "_Black";
		} else {
			pieceName += "_White";
		}
		this.col = 'A';
		this.col += (char)col;
		this.row = '1';
		this.row += (char)row;
		this.color = color;
		this.board = board;
        this.position = board.GetSquare(col, row);
	//	CalculateLegalMoves ();
	}

	public Piece(char col, char row, bool color, Board board){
		pieceName = this.GetType ().Name;
		if (color) {
			pieceName += "_Black";
		} else {
			pieceName += "_White";
		}
		this.col = col;
		this.row = row;
		this.color = color;
		this.board = board;
        this.position = board.GetSquare((int)(col - 'A'),(int)(row - '1'));
        //	CalculateLegalMoves ();
    }

	// Methods

	protected Move GenerateMove(Square movePosition){
		return new Move (color, this, position, movePosition);
	}

	protected Move GenerateMove(Square movePosition, Piece takenPiece){
		return new Move (color, this, position, movePosition, takenPiece);
	}


	public void SetPosition(Square pos){
		position = pos;
		col = pos.col;
		row = pos.row;
		CalculateLegalMoves ();
	}

	public override string ToString (){
		return pieceName;
	}

	/*
	public void Move(Square s){
		position.SetOccupant (null);
		if (s.isOccupied ()) {
			DeletePiece (s.GetOccupant ());
		}
		SetPosition (s);
	//	transform.position = s.transform.position;
		board.CalculateMoves ();
	}

	public void DeletePiece(Piece p){
		p.GetPosition ().SetOccupant (null);
		p.GetPlayer ().RemovePiece (p);
	//	GameObject.Destroy (p.gameObject);
	}
	*/


		
}
