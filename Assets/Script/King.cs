using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {

	private float value = 200;

	// Constructors

	public King (int col, int row, bool color, Board b) : base(col, row, color, b) { base.value = value; }

	// Methods

	public override void CalculateLegalMoves(){
        MonoBehaviour.print("White King added at " + position);
        legalMoves.Clear ();
		if (col < 'H' && row < '8') {
			if (!position.GetUpperRight().isOccupied() || position.GetUpperRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetUpperRight()));
			}
		}
		if (col < 'H' && row > '1') {
			if (!position.GetLowerRight().isOccupied() || position.GetLowerRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetLowerRight()));
			}
		}
		if (col > 'A' && row > '1') {
			if (!position.GetLowerLeft().isOccupied() || position.GetLowerLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetLowerLeft()));
			}
		}
		if (col > 'A' && row < '8') {
			if (!position.GetUpperLeft().isOccupied() || position.GetUpperLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetUpperLeft()));
			}
		}
		if (row < '8') {
			if (!position.GetUpper().isOccupied() || position.GetUpper ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetUpper()));
			}
		}
		if (col > 'A') {
			if (!position.GetLeft().isOccupied() || position.GetLeft ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetLeft()));
			}
		}
		if (col < 'H') {
			if (!position.GetRight().isOccupied() || position.GetRight ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetRight()));
			}
		}
		if (row > '1') {
			if (!position.GetLower().isOccupied() || position.GetLower ().GetOccupant ().GetColor () != this.color) {
				legalMoves.Add (GenerateMove(position.GetLower()));
			}
		}

		foreach (Move m in legalMoves) {
			if (new Board (board, m).Checked (color)) {
				legalMoves.Remove (m);
			}
		}
	}
	

}
