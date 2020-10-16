using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

    // public static readonly Move EMPTY_MOVE = new Move(true, null, null, null);

	public bool blackTurn;

    public bool takeMove;
    public bool promoteMove;
    public bool castleMove;
    public bool enPassant;
	 
    public char colFrom;
    public char colTo;

    public char rowFrom;
    public char rowTo;

    public int promoteTo = 0; // 1 - Q, 2 - R, 3 - B, 4 - N
    public int castle = 0; // 1 - K, 2 - Q

	// Constructors

	public Move(string notation, bool black){

	}

	public Move(bool turn, Piece piece, Square current, Square moved){
		blackTurn = turn;

        colFrom = current.col;
        colTo = moved.col;
        rowFrom = current.row;
        rowTo = moved.row;
        takeMove = false;
        promoteMove = false;
        castleMove = false;
        enPassant = false;
	}

	public Move(bool turn, Piece piece, Square current, Square moved, Piece pieceToTake){
		blackTurn = turn;
        colFrom = current.col;
        colTo = moved.col;
        rowFrom = current.row;
        rowTo = moved.row;
        takeMove = true;
        promoteMove = false;
        castleMove = false;
        enPassant = false;
    }

    public Move(bool turn, Piece piece, Square current, Square moved, int promoteTo) {
        blackTurn = turn;
        colFrom = current.col;
        colTo = moved.col;
        rowFrom = current.row;
        rowTo = moved.row;
        this.promoteTo = promoteTo;
        takeMove = false;
        promoteMove = true;
        castleMove = false;
        enPassant = false;
    }

    public Move(bool turn, Piece piece, Square current, Square moved, Piece pieceToTake, int promoteTo) {
        blackTurn = turn;
        colFrom = current.col;
        colTo = moved.col;
        rowFrom = current.row;
        rowTo = moved.row;
        this.promoteTo = promoteTo;
        takeMove = true;
        promoteMove = true;
        castleMove = false;
        enPassant = false;
    }

    public Move(bool turn, int castle) {
        blackTurn = turn;
        this.castle = castle;
        takeMove = false;
        promoteMove = false;
        castleMove = true;

       switch (castle) {
            case 1:
                if (blackTurn) {
                    colFrom = 'E';
                    rowFrom = '8';
                    colTo = 'G';
                    rowTo = '8';
                } else {
                    colFrom = 'E';
                    rowFrom = '1';
                    colTo = 'G';
                    rowTo = '1';
                } break;
            case 2:
                if (blackTurn) {
                    colFrom = 'E';
                    rowFrom = '8';
                    colTo = 'C';
                    rowTo = '8';
                }
                else {
                    colFrom = 'E';
                    rowFrom = '1';
                    colTo = 'C';
                    rowTo = '1';
                }
                break;
        }
    }

    public Move(Move m, Board b) {
        blackTurn = m.blackTurn;
        takeMove = m.takeMove;
        promoteMove = m.promoteMove;
        castleMove = m.castleMove;
        castle = m.castle;

        colFrom = m.colFrom;
        colTo = m.colTo;
        rowFrom = m.rowFrom;
        rowTo = m.rowTo;

        /// FIND A WAY TO COMPLETE OR REMOVE LAST MOVE FROM BOARD

    }




}
