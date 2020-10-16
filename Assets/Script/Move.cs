using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public static readonly Move EMPTY_MOVE = new Move(true, null, null, null);

	public bool blackTurn;

    public bool takeMove;
    public bool promoteMove;
    public bool castleMove;
	 
	public Piece pieceToMove; 
	public Square piecePosition;
	public Square movePoisition;

    public Piece pieceToTake;
    public string promoteTo;

    public int castle; // 1 - K, 2 - Q

	// Constructors

	public Move(string notation, bool black){

	}

	public Move(bool turn, Piece piece, Square current, Square moved){
		blackTurn = turn;
		pieceToMove = piece;
		piecePosition = current;
		movePoisition = moved;
        takeMove = false;
        promoteMove = false;
        castleMove = false;
	}

	public Move(bool turn, Piece piece, Square current, Square moved, Piece pieceToTake){
		blackTurn = turn;
		pieceToMove = piece;
		piecePosition = current;
		movePoisition = moved;
		this.pieceToTake = pieceToTake;
        takeMove = true;
        promoteMove = false;
        castleMove = false;
    }

    public Move(bool turn, Piece piece, Square current, Square moved, string promoteTo) {
        blackTurn = turn;
        pieceToMove = piece;
        piecePosition = current;
        movePoisition = moved;
        this.promoteTo = promoteTo;
        takeMove = false;
        promoteMove = true;
        castleMove = false;
    }

    public Move(bool turn, Piece piece, Square current, Square moved, Piece pieceToTake, string promoteTo) {
        blackTurn = turn;
        pieceToMove = piece;
        piecePosition = current;
        movePoisition = moved;
        this.pieceToTake = pieceToTake;
        this.promoteTo = promoteTo;
        takeMove = true;
        promoteMove = true;
        castleMove = false;
    }

    public Move(bool turn, int castle) {
        blackTurn = turn;
        this.castle = castle;
        takeMove = false;
        promoteMove = false;
        castleMove = true;
    }




}
