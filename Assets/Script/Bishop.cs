using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece {

	private float value = 3;

	// Constructors

	public Bishop (int col, int row, bool color) : base(col, row, color) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves (){
	/*
		legalMoves.Clear ();
		for (int k = 1; k < 8; k++) {
			if (row + k < 8 && col + k < 8) {
				if (!board.squares [col + k, row + k].isOccupied ()) {
					legalMoves.Add (board.squares [col + k, row + k]);
				} else if (board.squares [col + k, row + k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col + k, row + k]);
					break;
				} else {
					break;
				}
			}
		}
		for (int k = 1; k < 8; k++) {
			if (row + k < 8 && col - k >= 0) {
				if (!board.squares [col - k, row + k].isOccupied ()) {
					legalMoves.Add (board.squares [col - k, row + k]);
				} else if (board.squares [col - k, row + k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col - k, row + k]);
					break;
				} else {
					break;
				}
			}
		}
		for (int k = 1; k < 8; k++) {
			if (row - k >= 0 && col - k >= 0) {
				if (!board.squares [col - k, row - k].isOccupied ()) {
					legalMoves.Add (board.squares [col - k, row - k]);
				} else if (board.squares [col - k, row - k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col - k, row - k]);
					break;
				} else {
					break;
				}
			}
		}
		for (int k = 1; k < 8; k++) {
			if (row - k >= 0 && col + k < 8) {
				if (!board.squares [col + k, row - k].isOccupied ()) {
					legalMoves.Add (board.squares [col + k, row - k]);
				} else if (board.squares [col + k, row - k].GetOccupant ().GetColor () != color) {
					legalMoves.Add (board.squares [col + k, row - k]);
					break;
				} else {
					break;
				}
			}
		}
		*/
	}
		
}
