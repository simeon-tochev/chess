using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {


    // Constructors

    public King(char col, char row, bool color, Board b) : base(col, row, color, b) { }

    public King(Piece p, Board b) : base(p, b) { }

	// Methods

	public override List<Move> CalculateLegalMoves(){
        List<Move> legalMoves = new List<Move>();


        /*
        if (!hasMoved)
            if (color) {
                
            } else {

            }
       */
        
        
		if (col < 'H' && row < '8') {
			if (!position.GetUpperRight().isOccupied()  ) {
				legalMoves.Add (GenerateMove(position.GetUpperRight()));
			}
            else if(position.GetUpperRight().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetUpperRight(), position.GetUpperRight().GetOccupant()));
            }
		}
		if (col < 'H' && row > '1') {
			if (!position.GetLowerRight().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetLowerRight()));
			}
            else if (position.GetLowerRight().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetLowerRight(), position.GetLowerRight().GetOccupant()));
            }
        }
		if (col > 'A' && row > '1') {
			if (!position.GetLowerLeft().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetLowerLeft()));
			}
            else if (position.GetLowerLeft().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetLowerLeft(), position.GetLowerLeft().GetOccupant()));
            }
        }
		if (col > 'A' && row < '8') {
			if (!position.GetUpperLeft().isOccupied() ) {
				legalMoves.Add (GenerateMove(position.GetUpperLeft()));
			}
            else if (position.GetUpperLeft().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetUpperLeft(), position.GetUpperLeft().GetOccupant()));
            }
        }
		if (row < '8') {
			if (!position.GetUpper().isOccupied() ) {
				legalMoves.Add (GenerateMove(position.GetUpper()));
			}
            else if (position.GetUpper().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetUpper(), position.GetUpper().GetOccupant()));
            }
        }
		if (col > 'A') {
            
			if (!position.GetLeft().isOccupied()) {
				legalMoves.Add (GenerateMove(position.GetLeft()));
			}
            else if (position.GetLeft().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetLeft(), position.GetLeft().GetOccupant()));
            }
        }
		if (col < 'H') {
			if (!position.GetRight().isOccupied() ) {
				legalMoves.Add (GenerateMove(position.GetRight()));
			}
            else if (position.GetRight().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetRight(), position.GetRight().GetOccupant()));
            }
        }
		if (row > '1') {
			if (!position.GetLower().isOccupied() ) {
				legalMoves.Add (GenerateMove(position.GetLower()));
			}
            else if (position.GetLower().GetOccupant().color != color) {
                legalMoves.Add(GenerateMove(position.GetLower(), position.GetLower().GetOccupant()));
            }
        }

        return legalMoves;

	}
	

}
