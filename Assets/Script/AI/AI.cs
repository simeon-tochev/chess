using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI : Player
{

    public float timeTothink;

    public float timer;

    public int depth;

    protected void Start() {
        base.Start();
    }

    protected void Update() {
        if (ToPlay() && board.gameState == '1') {
            timer += Time.deltaTime;
            if(timer > timeTothink) {
                PlayMove();
            }
        } else {
            timer = 0;
        }
    }

    public void PlayMove() {
        if (ToPlay()) {
            GetLegalMoves();
            moveManager.MakeMove(GetBestMove());
            turnCount++;
        }
    }

    protected abstract Move GetBestMove();

    protected abstract float BoardEvaluate(Board b);

    protected abstract float MoveEvaluate(Move m);

}
