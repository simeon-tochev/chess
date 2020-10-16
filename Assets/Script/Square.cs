using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Square  {

	public char 	col;
	public char		row;

	public string 	abbreviation;

	public bool 	isBlack;

	public float 	value;

	public Board 	currentBoard;

	public Piece 	occupant;

	public SquareMono squareMono;

	// Constructors

	public Square(string abv){
		
	}

	public Square(int col, int row, Board b){
		char c = (char)col;
		c += 'A';
		this.col = c;
		char r = (char)row;
		r += '1';
		this.row = r;
		string s = c.ToString() + r.ToString();
		isBlack = ((row + col) % 2 == 0); 
		abbreviation = s;
        this.currentBoard = b;
	}

	public Square(char col, char row, Board b){
		this.col = col;
		this.row = row;
		string s = col.ToString() + row.ToString();
		abbreviation = s;
		isBlack = ((int)row + (int)col) % 2 == 0;
        this.currentBoard = b;
    }

	// Methods

	public Piece GetOccupant(){
		return occupant;
	//	return null;
	}

	public override string ToString () {
		return abbreviation;
	}

//	public void SetBoard(Board b){
//		currentBoard = b;
//		moveManager = GameObject.Find ("MoveManager").GetComponent<MoveManager> ();
//	}

	public bool isOccupied(){
		if (occupant != null) {
			return true;
		} else {
			return false;
		}
	}

	public Square GetUpper(){
		return currentBoard.GetUpper(this);
	}

	public Square GetLower(){
		return currentBoard.GetLower(this);
	}

	public Square GetRight(){
		return currentBoard.GetRight(this);
	}

	public Square GetLeft(){
		return currentBoard.GetLeft(this);
	}

	public Square GetUpperLeft(){
		return currentBoard.GetUpperLeft(this);
	}

	public Square GetLowerLeft(){
		return currentBoard.GetLowerLeft(this);
	}

	public Square GetUpperRight(){
		return currentBoard.GetUpperRight(this);
	}

	public Square GetLowerRight(){
		return currentBoard.GetLowerRight(this);
	}

    public string toString() {
        if (!isOccupied()) {
            return "E";
        }
        String str = occupant.pieceName;
        switch (str) {
            case "King_White": return "k";
            case "King_Black": return "K";
            case "Queen_White": return "q";
            case "Queen_Black": return "Q";
            case "Rook_White": return "r";
            case "Rook_Black": return "R";
            case "Knight_White": return "n";
            case "Knight_Black": return "N";
            case "Bishop_White": return "b";
            case "Bishop_Black": return "B";
            case "Pawn_White": return "p";
            case "Pawn_Black": return "P";
            default: return null;
        }
    }
}
