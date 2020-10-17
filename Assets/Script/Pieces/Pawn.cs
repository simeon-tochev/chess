using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece {


	// Constructors

	public Pawn(char col, char row, bool color, Board b) : base(col, row, color, b) { }

    public Pawn (Piece p, Board b) : base(p, b) { }

    // Methods

    Move GeneratePromoteMove(Square to, int promoteTo) {
        return new Move(color, this, position, to, promoteTo);
    }

    Move GeneratePromoteMove(Square to, int promoteTo, Piece take) {
        return new Move(color, this, position, to, take, promoteTo);
    }

    Move GenerateEnPassant(Square to) {
        Move m = new Move(color, this, position, to, true);
     //   Debug.Log("EnPassant: " + m.enPassant);
        return m;
    }

    public override List<Move> CalculateLegalMoves(){
        List<Move> legalMoves = new List<Move>();
		if (!color) {
            if (row < '7') {
                if (row == '2' && !color) {
                    if (!position.GetUpper().GetUpper().isOccupied() && !position.GetUpper().isOccupied()) {
                        legalMoves.Add(GenerateMove(position.GetUpper().GetUpper()));
                    }
                }
                if (!position.GetUpper().isOccupied()) {
                    legalMoves.Add(GenerateMove(position.GetUpper()));
                }
                if (col < 'H' && position.GetUpperRight().isOccupied()) {
                    if (position.GetUpperRight().GetOccupant().color != color) {
                        legalMoves.Add(GenerateMove(position.GetUpperRight(), position.GetUpperRight().occupant));
                    }
                }
                if (col > 'A' && position.GetUpperLeft().isOccupied()) {
                    if (position.GetUpperLeft().GetOccupant().color != color) {
                        legalMoves.Add(GenerateMove(position.GetUpperLeft(), position.GetUpperLeft().occupant));
                    }
                }

                if(row == '5') {
                    if(col < 'H' && position.GetRight().isOccupied() && position.GetRight().occupant.enPassant) {
                        legalMoves.Add(GenerateEnPassant(position.GetUpperRight()));
                    }
                    if (col > 'A' && position.GetLeft().isOccupied() && position.GetLeft().occupant.enPassant) {
                        legalMoves.Add(GenerateEnPassant(position.GetUpperLeft()));
                    }
                }
            }

            if(row == '7') {
                if (!position.GetUpper().isOccupied()) {
                    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 1));
                //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 2);
                //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 3);
                //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 4);
                }
                if (col < 'H' && position.GetUpperRight().isOccupied()) {
                    if (position.GetUpperRight().GetOccupant().color != color) {
                        legalMoves.Add(GeneratePromoteMove(position.GetUpperRight(), 1, position.GetUpperRight().GetOccupant()));
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 2, position.GetUpperRight().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 3, position.GetUpperRight().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 4, position.GetUpperRight().GetOccupant());
                    }
                }
                if (col > 'A' && position.GetUpperLeft().isOccupied()) {
                    if (position.GetUpperLeft().GetOccupant().color != color) {
                        legalMoves.Add(GeneratePromoteMove(position.GetUpperLeft(), 1, position.GetUpperLeft().GetOccupant()));
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 2, position.GetUpperLeft().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 3, position.GetUpperLeft().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 4, position.GetUpperLeft().GetOccupant());
                    }
                }
            }
		} else {
            if (row > '2') {
                if (row == '7' && color) {
                    if (!position.GetLower().GetLower().isOccupied() && !position.GetLower().isOccupied()) {
                        legalMoves.Add(GenerateMove(position.GetLower().GetLower()));
                    }
                }
                if (!position.GetLower().isOccupied()) {
                    legalMoves.Add(GenerateMove(position.GetLower()));
                }
                if (col < 'H' && position.GetLowerRight().isOccupied()) {
                    if (position.GetLowerRight().GetOccupant().color != color) {
                        legalMoves.Add(GenerateMove(position.GetLowerRight(), position.GetLowerRight().occupant));
                    }
                }
                if (col > 'A' && position.GetLowerLeft().isOccupied()) {
                    if (position.GetLowerLeft().GetOccupant().color != color) {
                        legalMoves.Add(GenerateMove(position.GetLowerLeft(), position.GetLowerLeft().occupant));
                    }
                }

                if (row == '4') {
                    if (col < 'H' && position.GetRight().isOccupied() && position.GetRight().occupant.enPassant) {
                        legalMoves.Add(GenerateEnPassant(position.GetLowerRight()));
                    }
                    if (col > 'A' && position.GetLeft().isOccupied() && position.GetLeft().occupant.enPassant) {
                        legalMoves.Add(GenerateEnPassant(position.GetLowerLeft()));
                    }
                }
            }

            if (row == '2') {
                if (!position.GetLower().isOccupied()) {
                    legalMoves.Add(GeneratePromoteMove(position.GetLower(), 1));
                    //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 2);
                    //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 3);
                    //    legalMoves.Add(GeneratePromoteMove(position.GetUpper(), 4);
                }
                if (col < 'H' && position.GetLowerRight().isOccupied()) {
                    if (position.GetLowerRight().GetOccupant().color != color) {
                        legalMoves.Add(GeneratePromoteMove(position.GetLowerRight(), 1, position.GetLowerRight().GetOccupant()));
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerRight(), 2, position.GetLowerRight().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerRight(), 3, position.GetLowerRight().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerRight(), 4, position.GetLowerRight().GetOccupant());
                    }
                }
                if (col > 'A' && position.GetLowerLeft().isOccupied()) {
                    if (position.GetLowerLeft().GetOccupant().color != color) {
                        legalMoves.Add(GeneratePromoteMove(position.GetLowerLeft(), 1, position.GetLowerLeft().GetOccupant()));
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerLeft(), 2, position.GetLowerLeft().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerLeft(), 3, position.GetLowerLeft().GetOccupant());
                        //    legalMoves.Add(GeneratePromoteMove(position.GetLowerLeft(), 4, position.GetLowerLeft().GetOccupant());
                    }
                }
            }
        }
        return legalMoves;

	}

}
