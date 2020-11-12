using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAI : AI
{
    private string e = "ee";
    protected override Move GetBestMove() {
        int r = Random.Range(0, legalMoves.Count - 1);
        return legalMoves[r];
    }

    protected override float MoveEvaluate(Move m) {
        return 0f;
    }

    protected override float BoardEvaluate(Board b){
        return 0f;
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
