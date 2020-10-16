using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece {

	// Constructors

	public Knight (char col, char row, bool color, Board b) : base(col, row, color, b) {}

	// Methods

	public override List<Move> CalculateLegalMoves(){

        List<Move> legalMoves = new List<Move>();
		if (row < '7') {
			if (col < 'H') {
				if (!position.GetUpper ().GetUpperRight ().isOccupied ()) {
					legalMoves.Add (GenerateMove( position.GetUpper ().GetUpperRight ()));
				} else if (position.GetUpper ().GetUpperRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetUpper ().GetUpperRight () , position.GetUpper().GetUpperRight().occupant));
				}
			}
			if (col > 'A') {
				if (!position.GetUpper ().GetUpperLeft ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetUpper ().GetUpperLeft ()));
				} else if (position.GetUpper ().GetUpperLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetUpper ().GetUpperLeft (), position.GetUpper().GetUpperLeft().occupant));
				}
			}
		}
		if (row > '2') {
			if (col < 'H') {
				if (!position.GetLower ().GetLowerRight ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetLower ().GetLowerRight ()));
				} else if (position.GetLower ().GetLowerRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLower ().GetLowerRight (), position.GetLower().GetLowerRight().occupant));
				}
			}
			if (col > 'A') {
				if (!position.GetLower ().GetLowerLeft ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetLower ().GetLowerLeft ()));
				} else if (position.GetLower ().GetLowerLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLower ().GetLowerLeft (), position.GetLower().GetLowerLeft().occupant));
				}
			}
		}
		if (col < 'G') {
			if (row < '8') {
				if (!position.GetRight ().GetUpperRight ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetRight ().GetUpperRight ()));
				} else if (position.GetRight ().GetUpperRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetRight ().GetUpperRight (), position.GetRight().GetUpperRight().occupant));
				}
			}
			if (row > '1') {
				if (!position.GetRight ().GetLowerRight ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetRight ().GetLowerRight ()));
				} else if (position.GetRight ().GetLowerRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetRight ().GetLowerRight (), position.GetRight().GetLowerRight().occupant));
				}
			}
		}
		if (col > 'B') {
			if (row < '8') {
				if (!position.GetLeft ().GetUpperLeft ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetLeft ().GetUpperLeft ()));
				} else if (position.GetLeft ().GetUpperLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLeft ().GetUpperLeft (), position.GetLeft().GetUpperLeft().occupant));
				}
			}
			if (row > '1') {
				if (!position.GetLeft ().GetLowerLeft ().isOccupied ()) {
					legalMoves.Add (GenerateMove(position.GetLeft ().GetLowerLeft ()));
				} else if (position.GetLeft ().GetLowerLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLeft ().GetLowerLeft (), position.GetLeft().GetLowerLeft().occupant));
				}
			}
		}
        return legalMoves;
		
	}

}
