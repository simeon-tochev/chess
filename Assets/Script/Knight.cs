using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece {

	private float value = 3;

	// Constructors

	public Knight (int col, int row, bool color) : base(col, row, color) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves(){
		/*
		legalMoves.Clear ();
		if (row < 6) {
			if (col < 7) {
				if (!position.GetUpper ().GetUpperRight ().isOccupied ()) {
					legalMoves.Add (position.GetUpper ().GetUpperRight ());
				} else if (position.GetUpper ().GetUpperRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetUpper ().GetUpperRight ());
				}
			}
			if (col > 0) {
				if (!position.GetUpper ().GetUpperLeft ().isOccupied ()) {
					legalMoves.Add (position.GetUpper ().GetUpperLeft ());
				} else if (position.GetUpper ().GetUpperLeft ().GetOccupant ().GetColor() != color) {
					legalMoves.Add (position.GetUpper ().GetUpperLeft ());
				}
			}
		}
		if (row > 1) {
			if (col < 7) {
				if (!position.GetLower ().GetLowerRight ().isOccupied ()) {
					legalMoves.Add (position.GetLower ().GetLowerRight ());
				} else if (position.GetLower ().GetLowerRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetLower ().GetLowerRight ());
				}
			}
			if (col > 0) {
				if (!position.GetLower ().GetLowerLeft ().isOccupied ()) {
					legalMoves.Add (position.GetLower ().GetLowerLeft ());
				} else if (position.GetLower ().GetLowerLeft ().GetOccupant ().GetColor() != color) {
					legalMoves.Add (position.GetLower ().GetLowerLeft ());
				}
			}
		}
		if (col < 6) {
			if (row < 7) {
				if (!position.GetRight ().GetUpperRight ().isOccupied ()) {
					legalMoves.Add (position.GetRight ().GetUpperRight ());
				} else if (position.GetRight ().GetUpperRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetRight ().GetUpperRight ());
				}
			}
			if (row > 0) {
				if (!position.GetRight ().GetLowerRight ().isOccupied ()) {
					legalMoves.Add (position.GetRight ().GetLowerRight ());
				} else if (position.GetRight ().GetLowerRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetRight ().GetLowerRight ());
				}
			}
		}
		if (col > 1) {
			if (row < 7) {
				if (!position.GetLeft ().GetUpperLeft ().isOccupied ()) {
					legalMoves.Add (position.GetLeft ().GetUpperLeft ());
				} else if (position.GetLeft ().GetUpperLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetLeft ().GetUpperLeft ());
				}
			}
			if (row > 0) {
				if (!position.GetLeft ().GetLowerLeft ().isOccupied ()) {
					legalMoves.Add (position.GetLeft ().GetLowerLeft ());
				} else if (position.GetLeft ().GetLowerLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (position.GetLeft ().GetLowerLeft ());
				}
			}
		}
		*/
	}

}
