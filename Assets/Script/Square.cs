using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square  {

	public string 	abbreviation;

	public bool 	isBlack;

	public float 	value;

	public Board 	currentBoard;

	public Piece 	occupant;

	// Constructors

	public Square(string abv){
		
	}

	public Square(int col, int row){
		char c = (char)col;
		c += 'A';
		char r = (char)row;
		r += '1';
		string s = c.ToString() + r.ToString();
		isBlack = ((row + col) % 2 == 0); 
		abbreviation = s;
	}

	public Square(char col, char row){
		string s = col.ToString() + row.ToString();
		abbreviation = s;
		isBlack = ((int)row + (int)col) % 2 == 0;
	}

	// Methods

	public Piece GetOccupant(){
	//	return occupant;
		return null;
	}

	public override string ToString () {
		return abbreviation;
	}

//	public void SetBoard(Board b){
//		currentBoard = b;
//		moveManager = GameObject.Find ("MoveManager").GetComponent<MoveManager> ();
//	}

//	public bool isOccupied(){
//	//	if (!occupant.Equals(null)) {
//	//		return true;
//	//	} else {
//	//		return false;
//	//	}
//	}
//
//	public Square GetUpper(){
//		return currentBoard.GetUpper(this);
//	}
//
//	public Square GetLower(){
//		return currentBoard.GetLower(this);
//	}
//
//	public Square GetRight(){
//		return currentBoard.GetRight(this);
//	}
//
//	public Square GetLeft(){
//		return currentBoard.GetLeft(this);
//	}
//
//	public Square GetUpperLeft(){
//		return currentBoard.GetUpperLeft(this);
//	}
//
//	public Square GetLowerLeft(){
//		return currentBoard.GetLowerLeft(this);
//	}
//
//	public Square GetUpperRight(){
//		return currentBoard.GetUpperRight(this);
//	}
//
//	public Square GetLowerRight(){
//		return currentBoard.GetLowerRight(this);
//	}
}
