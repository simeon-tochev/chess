using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece {

	private float value = 5;

	// Constructors

	public Rook (int col, int row, bool color) : base(col, row, color) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves (){
		/*
		legalMoves.Clear ();
		for (int k = 1; k < 8; k++) {
			if (col + k < 8) {
				if (!board.squares [col + k, row].isOccupied ()) {
					legalMoves.Add (board.squares [col + k, row]);
				} else if (board.squares [col + k, row].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col + k, row]);
					break;
				} else {
					break;
				}
			} 
		}
		for (int k = 1; k < 8; k++) {
			if (col - k >= 0) {
				if (!board.squares [col - k, row].isOccupied ()) {
					legalMoves.Add (board.squares [col - k, row]);
				} else if (board.squares [col - k, row].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col - k, row]);
					break;
				} else {
					break;
				}
			}
		}
		for (int k = 1; k < 8; k++) {
			if (row + k < 8) {
				if (!board.squares [col, row + k].isOccupied ()) {
					legalMoves.Add (board.squares [col, row + k]);
				} else if (board.squares [col, row + k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col, row + k]);
					break;
				} else {
					break;
				}
			}
		}
		for (int k = 1; k < 8; k++) {
			if (row - k >= 0) {
				if (!board.squares [col, row - k].isOccupied ()) {
					legalMoves.Add (board.squares [col, row - k]);
				} else if (board.squares [col, row - k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col, row - k]);
					break;
				} else {
					break;
				}
			}
		}
		*/
	}
		
}
