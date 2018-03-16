using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece  {

	public string		pieceName;

	public char 		col;				//  Mimic the collumn and row						
	public char 		row;   				//	properties of the square

	public float 		value { get; protected set;} 		// 1 pawn 3 knight/bishop 5 rook 9 queen

	public bool			color; 				// True for black

	public Square 		position;

	public ArrayList 	legalMoves = new ArrayList();

	public MoveManager 	moveManager;


	// Abstract Methods and Properties

	public abstract void 	CalculateLegalMoves();

	// Constructors

	public Piece(int col, int row, bool color){
		pieceName = this.GetType ().Name;
		if (color) {
			pieceName += "_Black";
		} else {
			pieceName += "_White";
		}
		CalculateLegalMoves ();
		this.col = 'A';
		this.col += (char)col;
		this.row = '1';
		this.row += (char)row;
		this.color = color;
	}

	// Methods


	public override string ToString (){
		return pieceName;
	}

	public bool GetColor(){
		return color;
	}

	public void SetColor(bool c){
		color = c;
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

	void OnMouseDown(){
		if (moveManager.GetTurn () == color) {
			moveManager.SelectPiece (this);
		} else {
		//	moveManager.SelectSquare (position);
		}
	}
		
}
