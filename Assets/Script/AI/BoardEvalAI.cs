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
    private float squareControlEval = 0.01f;
    private float castleEval = 1f;

    private float checkEval = 0.5f;

    private float queenAttackEval = 1.5f;
    private float rookaAttackEval = 0.5f;
    private float pieceAttackEval = 0.3f;
    private float pawnAttackEval = 0.1f;
    
    private float queenProtectEval = 0.1f;
    private float rookProtectEval = 0.2f;
    private float pieceProtectEval = 0.2f;
    private float pawnProtectEval = 0.1f;

    private float pawnMoveEval = 0.3f;


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
            if(q != null && q.position == board.squares[m.colFrom - 'A', m.rowFrom - '1']) {
                eval += 0.5f;
            }

            if(board.squares[m.colFrom - 'A', m.rowFrom - '1'].isOccupied() && board.squares[m.colFrom - 'A', m.rowFrom - '1'].occupant.pieceName == "Pawn_Black") {
                eval -= pawnMoveEval;
            }

        } else {
            if (m.castle > 0) {
                eval += castleEval;
            }

            Piece q = board.pieces.Find(p => p.pieceName == "Queen_White");
            if (q != null && q.position == board.squares[m.colFrom - 'A', m.rowFrom - '1']) {
                eval -= 0.5f;
            }

            if (board.squares[m.colFrom - 'A', m.rowFrom - '1'].isOccupied() && board.squares[m.colFrom - 'A', m.rowFrom - '1'].occupant.pieceName == "Pawn_White") {
                eval += pawnMoveEval;
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
            Piece p = board.squares[m.colTo - 'A', m.rowTo - '1'].occupant;
            if(p != null) {
                switch (p.pieceName) {
                    case "King_White": 
                        eval -= checkEval; 
                        break;

                    case "Queen_White": eval -= queenAttackEval; break;
                    case "Rook_White": eval -= rookaAttackEval; break;
                    case "Bishop_White": eval -= pieceAttackEval; break;
                    case "Knight_White": eval -= pieceAttackEval; break;
                    case "Pawn_White": eval -= pawnAttackEval; break;

                    case "Queen_Black": eval -= queenProtectEval; break;
                    case "Rook_Black": eval -= rookProtectEval; break;
                    case "Bishop_Black": eval -= pieceProtectEval; break;
                    case "Knight_Black": eval -= pieceProtectEval; break;
                    case "Pawn_Black": eval -= pawnProtectEval; break;
                }
            }
            eval -= squareControlEval;
        }

        foreach (Move m in whiteMoves) {
            if (m.castle > 0) {
                eval += castleEval / 2;
            }
            Piece p = board.squares[m.colTo - 'A', m.rowTo - '1'].occupant;
            if (p != null) {
                switch (p.pieceName) {
                    case "King_Black": eval += checkEval; break;

                    case "Queen_Black": eval += queenAttackEval; break;
                    case "Rook_Black": eval -= rookaAttackEval; break;
                    case "Bishop_Black": eval += pieceAttackEval; break;
                    case "Knight_Black": eval += pieceAttackEval; break;
                    case "Pawn_Black": eval += pawnProtectEval; break;

                    case "Queen_White": eval += queenProtectEval; break;
                    case "Rook_White": eval -= rookProtectEval; break;
                    case "Bishop_White": eval += pieceProtectEval; break;
                    case "Knight_White": eval += pieceProtectEval; break;
                    case "Pawn_White": eval += pawnProtectEval; break;
                }
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
