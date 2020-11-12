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
        // PlayMove();
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
