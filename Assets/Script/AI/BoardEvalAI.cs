using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEvalAI : AI
{
    private float kingEval = 200f;
    private float queenEval = 9;
    private float rookEval = 5;
    private float bishopEval = 3;
    private float knightEval = 3;
    private float pawnEval = 1;
    private float squareControlEval = 0.015f;
    private float castleEval = 1f;

    private float checkEval = 0.1f;

     
    protected override Move GetBestMove() {
        Move maxMove = null;
        float maxEval = 0;
        if (color) {
            maxEval = 1000;
            foreach (Move m in legalMoves) {
                float eval = MoveEvaluate(m);
                if(eval < maxEval) {
                    maxEval = eval;
                    maxMove = m;
                }
            }
        } else {
            maxEval = -1000;
            foreach (Move m in legalMoves) {
                float eval = MoveEvaluate(m);
                if (eval > maxEval) {
                    maxEval = eval;
                    maxMove = m;
                }
            }
        }
        print(maxEval);
        return maxMove;
    }

    protected override float MoveEvaluate(Move m) {
        float eval = 0f;
        Board b = board.GetNextBoard(m);
        eval = BoardEvaluate(b);
        if (color) {
            if (m.castle > 0) {
                eval -= castleEval;
            }

            Piece q = board.pieces.Find(p => p.pieceName == "Queen_Black");
            if(q != null && turnCount < 10 && q.position == board.squares[m.colFrom - 'A', m.rowFrom - '1']) {
                eval += 1;
            }
        } else {
            if (m.castle > 0) {
                eval += castleEval;
            }

            Piece q = board.pieces.Find(p => p.pieceName == "Queen_White");
            if (turnCount < 10 && q.position == board.squares[m.colFrom - 'A', m.rowFrom - '1']) {
                eval -= 1;
            }
        }

        return eval;
    }

    protected override float BoardEvaluate(Board b) {
        float eval = 0f;
        foreach(Piece p in b.pieces) {
            switch (p.pieceName) {
                case "King_Black": eval -= kingEval; break;
                case "King_White": eval += kingEval; break;

                case "Queen_Black": eval -= queenEval; break;
                case "Queen_White": eval += queenEval; break;

                case "Rook_Black": eval -= rookEval; break;
                case "Rook_White": eval += rookEval; break;

                case "Bishop_Black": eval -= bishopEval; break;
                case "Bishop_White": eval += bishopEval; break;

                case "Knight_Black": eval -= knightEval; break;
                case "Knight_White": eval += knightEval; break;

                case "Pawn_Black": eval -= pawnEval; break;
                case "Pawn_White": eval += pawnEval; break;
            }
        }
        List<Move> blackMoves = b.GetMoves(true);
        List<Move> whiteMoves = b.GetMoves(false);

        foreach(Move m in blackMoves) {
            if (m.castle > 0) {
                eval -= castleEval / 2;
            }
            Piece k = b.pieces.Find(p => p.pieceName == "King_White");
            if (k.position == board.squares[m.colTo - 'A', m.rowTo - '1']) {
                eval -= checkEval;
            }
            eval -= squareControlEval;
        }

        foreach (Move m in whiteMoves) {
            if (m.castle > 0) {
                eval += castleEval / 2;
            }
            Piece k = b.pieces.Find(p => p.pieceName == "King_Black");
            if (k.position == board.squares[m.colTo - 'A', m.rowTo - '1']) {
                eval += checkEval;
            }
            eval += squareControlEval;
        }

        return eval;
    }

        // Start is called before the first frame update
    void Start() {
        base.Start();

    }

    // Update is called once per frame
    void Update() {
        base.Update();
    }
}
