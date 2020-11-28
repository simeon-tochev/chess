using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEvalAIDepth : AI
{
	public static int maxDepth = 1;

    private float kingEval = 200f;
    private float queenEval = 9;
    private float rookEval = 5;
    private float bishopEval = 3;
    private float knightEval = 3;
    private float pawnEval = 1;
    private float squareControlEval = 0.01f;

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

    protected override float BoardEvaluate(Board b) {
        if (b.gameState != '1') {
            switch (b.gameState) {
                case '2':
                case '4': return 1000f;
                case '3':
                case '5': return -1000f;
                default: return 0f;
            }
        }

        float eval = 0f;
        foreach (Piece p in b.pieces) {
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

        foreach (Move m in blackMoves) {
            Piece p = board.squares[m.colTo - 'A', m.rowTo - '1'].occupant;
            if (p != null) {
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


	protected override Move GetBestMove() {
		float alpha = -10000f;
		float beta = 10000f;
		List<Move> legalMoves = board.legalMoves;
		List<Move> bestMoves = new List<Move>();
		if (!color) {
			foreach (Move m in legalMoves) {
				Board nextBoard = new Board(board);
				nextBoard.MakeMove(m);
				float eval = MiniMax(nextBoard, -10000, 10000, false, maxDepth);
				if (eval > alpha) {
					bestMoves = new List<Move>();
					bestMoves.Add(m);
					alpha = eval;
				} else if (eval == alpha) {
					bestMoves.Add(m);
				}
			}
		} else {
			foreach (Move m in legalMoves) {
				Board nextBoard = new Board(board);
				nextBoard.MakeMove(m);
				float eval = MiniMax(nextBoard, -10000, 10000, true, maxDepth);
				if (eval < beta) {
					bestMoves = new List<Move>();
					bestMoves.Add(m);
					beta = eval;
				} else if (eval == beta) {
					bestMoves.Add(m);
				}
			}
		}
		int i = Random.Range(0, bestMoves.Count);
		return bestMoves[i];
	}

    protected override float MoveEvaluate(Move m) {
        throw new System.NotImplementedException();
    }

	float MiniMax(Board b, float alpha, float beta, bool player, int depth) {
		if (b.gameState != '1' || depth == 0) {
            return BoardEvaluate(b);
		}
		float v;
		if (player) {
			v = -10000f;
			foreach (Board nextBoard in b.GetNextBoards()) {
				float eval = MiniMax(nextBoard, alpha, beta, false, depth - 1);
				v = Mathf.Max(v, eval);
				alpha = Mathf.Max(alpha, v);
				if (beta <= alpha) { break; }
			}
		} else {
			v = 10000f;
			foreach (Board nextBoard in b.GetNextBoards()) {
				float eval = MiniMax(nextBoard, alpha, beta, true, depth - 1);
				v = Mathf.Max(v, eval);
				beta = Mathf.Min(beta, v);
				if (beta <= alpha) { break; }
			}
		}
		return v;
	}

	// Start is called before the first frame update
	void Start()
    {
        base.Start();   
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
