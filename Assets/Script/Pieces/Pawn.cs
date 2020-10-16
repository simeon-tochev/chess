using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {


	// Constructors

	public Pawn(char col, char row, bool color, Board b) : base(col, row, color, b) { }

    public Pawn (Piece p, Board b) : base(p, b) { }

    // Methods

    public override List<Move> CalculateLegalMoves(){
        List<Move> legalMoves = new List<Move>();
		if (!color) {
			if (row == '2'  && !color) {
				if (!position.GetUpper().GetUpper().isOccupied() && !position.GetUpper().isOccupied()) {
					legalMoves.Add (GenerateMove(position.GetUpper().GetUpper()));
				}
			}
			if (!position.GetUpper().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetUpper()));
			}
			if (col < 'H' && position.GetUpperRight ().isOccupied()) {
				if (position.GetUpperRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetUpperRight (), position.GetUpperRight().occupant));
				}
			}
			if (col > 'A' && position.GetUpperLeft ().isOccupied()) {
				if (position.GetUpperLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetUpperLeft (), position.GetUpperLeft().occupant));
				}
			}
		} else {
			if (row == '7' && color) {
				if (!position.GetLower().GetLower().isOccupied () && !position.GetLower().isOccupied()) {
					legalMoves.Add (GenerateMove(position.GetLower().GetLower()));
				}
			}
			if (!position.GetLower().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetLower ()));
			}
			if (col < 'H' && position.GetLowerRight ().isOccupied()) {
				if (position.GetLowerRight ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLowerRight (), position.GetLowerRight().occupant));
				}
			}
			if (col > 'A' && position.GetLowerLeft ().isOccupied()) {
				if (position.GetLowerLeft ().GetOccupant ().color != color) {
					legalMoves.Add (GenerateMove(position.GetLowerLeft (), position.GetLowerLeft().occupant));
				}
			}
		}
        return legalMoves;

	}

}
