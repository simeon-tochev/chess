using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {

	private float value = 1;

	// Constructors

	public Pawn(int col, int row, bool color) : base(col, row, color) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves(){
		/*
		legalMoves.Clear ();
		if (!color) {
			if (row == 1  && !color) {
				if (!position.GetUpper().GetUpper().isOccupied()) {
					legalMoves.Add (position.GetUpper().GetUpper());
				}
			}
			if (!position.GetUpper().isOccupied()) {
				legalMoves.Add (position.GetUpper());
			}
			if (col < 7 && position.GetUpperRight ().isOccupied()) {
				if (position.GetUpperRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetUpperRight ());
				}
			}
			if (col > 0 && position.GetUpperLeft ().isOccupied()) {
				if (position.GetUpperLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetUpperLeft ());
				}
			}
		} else {
			if (row == 6 && color) {
				if (!position.GetLower().GetLower().isOccupied ()) {
					legalMoves.Add (position.GetLower().GetLower());
				}
			}
			if (!position.GetLower().isOccupied()) {
				legalMoves.Add (position.GetLower());
			}
			if (col < 7 && position.GetLowerRight ().isOccupied()) {
				if (position.GetLowerRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetLowerRight ());
				}
			}
			if (col > 0 && position.GetLowerLeft ().isOccupied()) {
				if (position.GetLowerLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetLowerLeft ());
				}
			}
		}
		*/
	}

}
