using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {

	private float value = 200;

	// Constructors

	public King (int col, int row, bool color) : base(col, row, color) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves(){
	/*	legalMoves.Clear ();
		if (col < 7 && row < 7) {
			if (!position.GetUpperRight().isOccupied() || position.GetUpperRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetUpperRight ());
			}
		}
		if (col < 7 && row > 0) {
			if (!position.GetLowerRight().isOccupied() || position.GetLowerRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetLowerRight ());
			}
		}
		if (col > 0 && row > 0) {
			if (!position.GetLowerLeft().isOccupied() || position.GetLowerLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetLowerLeft ());
			}
		}
		if (col > 0 && row < 7) {
			if (!position.GetUpperLeft().isOccupied() || position.GetUpperLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetUpperLeft ());
			}
		}
		if (row < 7) {
			if (!position.GetUpper().isOccupied() || position.GetUpper ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetUpper ());
			}
		}
		if (col > 0) {
			if (!position.GetLeft().isOccupied() || position.GetLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetLeft ());
			}
		}
		if (col < 7) {
			if (!position.GetRight().isOccupied() || position.GetRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetRight ());
			}
		}
		if (row > 0) {
			if (!position.GetLower().isOccupied() || position.GetLower ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (position.GetLower ());
			}
		}
		*/
	}
	

}
