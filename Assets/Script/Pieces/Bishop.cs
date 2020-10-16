using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece {


	// Constructors

	public Bishop (char col, char row, bool color, Board b) : base(col, row, color, b) { }

    public Bishop (Piece p, Board b) : base(p, b) { }

    // Methods

    public override List<Move> CalculateLegalMoves (){

        List<Move> legalMoves = new List<Move>();
        for (int k = 1; k < 8; k++) {
            if (col + k < 'I' && row + k < '9') {
                if (!board.squares[col + k - 'A', row + k - '1'].isOccupied()) {
                    legalMoves.Add(GenerateMove(board.squares[col + k - 'A', row + k - '1']));
                }
                else if (board.squares[col + k - 'A', row + k - '1'].GetOccupant().color != color) {
                    legalMoves.Add(GenerateMove(board.squares[col + k - 'A', row + k - '1'], board.squares[col + k - 'A', row + k - '1'].GetOccupant()));
                    break;
                }
                else {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++) {

            if (col - k >= 'A' && row + k < '9') {
                if (!board.squares[col - k - 'A', row + k - '1'].isOccupied()) {
                    legalMoves.Add(GenerateMove(board.squares[col - k - 'A', row + k - '1']));
                }
                else if (board.squares[col - k - 'A', row + k - '1'].GetOccupant().color != color) {
                    legalMoves.Add(GenerateMove(board.squares[col - k - 'A', row + k - '1'], board.squares[col - k - 'A', row + k - '1'].GetOccupant()));
                    break;
                }
                else {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++) {

            if (col - k >= 'A' && row - k >= '1') {
                if (!board.squares[col - k - 'A', row - k - '1'].isOccupied()) {
                    legalMoves.Add(GenerateMove(board.squares[col - k - 'A', row - k - '1']));
                }
                else if (board.squares[col - k - 'A', row - k - '1'].GetOccupant().color != color) {
                    legalMoves.Add(GenerateMove(board.squares[col - k - 'A', row - k - '1'], board.squares[col - k - 'A', row - k - '1'].GetOccupant()));
                    break;
                }
                else {
                    break;
                }
            }

        }

        for (int k = 1; k < 8; k++) {

            if (col + k < 'I' && row - k >= '1') {
                if (!board.squares[col + k - 'A', row - k - '1'].isOccupied()) {
                    legalMoves.Add(GenerateMove(board.squares[col + k - 'A', row - k - '1']));
                }
                else if (board.squares[col + k - 'A', row - k - '1'].GetOccupant().color != color) {
                    legalMoves.Add(GenerateMove(board.squares[col + k - 'A', row - k - '1'], board.squares[col + k - 'A', row - k - '1'].GetOccupant()));
                    break;
                }
                else {
                    break;
                }
            }

        }

        return legalMoves;
	}
		
}
