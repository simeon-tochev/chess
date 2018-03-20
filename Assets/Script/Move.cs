using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public bool blackTurn;
	public bool takeMove;
	 
	public Piece pieceToMove; 
	public Square piecePosition;
	public Square movePoisition;

	// Constructors

	public Move(string notation, bool black){

	}

	public Move(bool turn, Piece piece, Square current, Square moved){
		blackTurn = turn;
		pieceToMove = piece;
		piecePosition = current;
		movePoisition = moved;
		takeMove = true;
	}

	public Move(bool turn, Piece piece, Square current, Square moved, bool takeMove){
		blackTurn = turn;
		pieceToMove = piece;
		piecePosition = current;
		movePoisition = moved;
		this.takeMove = takeMove;
	}
}
