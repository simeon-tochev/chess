using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {

	private float value = 1;

	// Constructors

	public Pawn(int col, int row, bool color, Board b) : base(col, row, color, b) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves(){
		
		legalMoves.Clear ();
		if (!color) {
			if (row == 1  && !color) {
				if (!position.GetUpper().GetUpper().isOccupied()) {
					legalMoves.Add (GenerateMove(position.GetUpper().GetUpper(), false));
				}
			}
			if (!position.GetUpper().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetUpper(), false));
			}
			if (col < 7 && position.GetUpperRight ().isOccupied()) {
				if (position.GetUpperRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (GenerateMove(position.GetUpperRight ()));
				}
			}
			if (col > 0 && position.GetUpperLeft ().isOccupied()) {
				if (position.GetUpperLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (GenerateMove(position.GetUpperLeft ()));
				}
			}
		} else {
			if (row == 6 && color) {
				if (!position.GetLower().GetLower().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetLower().GetLower(), false));
				}
			}
			if (!position.GetLower().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetLower (), false));
			}
			if (col < 7 && position.GetLowerRight ().isOccupied()) {
				if (position.GetLowerRight ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (GenerateMove(position.GetLowerRight ()));
				}
			}
			if (col > 0 && position.GetLowerLeft ().isOccupied()) {
				if (position.GetLowerLeft ().GetOccupant ().GetColor () != color) {
					legalMoves.Add (GenerateMove(position.GetLowerLeft ()));
				}
			}
		}

		foreach (Move m in legalMoves) {
			if (new Board (board, m).Checked (color)) {
				legalMoves.Remove (m);
			}
		}
	}

}
