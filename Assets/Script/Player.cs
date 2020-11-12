using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool color;

	public List<Move> legalMoves = new List<Move> ();
    public List<Piece> pieces = new List<Piece>();

    public MoveManager moveManager;

    public Board board;

    public int turnCount = 0;

    protected void Start() {
        board = GameObject.Find("BoardGenerator").GetComponent<BoardGenerator>().board;
        moveManager = GameObject.Find("MoveManager").GetComponent<MoveManager>();
        legalMoves = new List<Move>();
    }

    // Constructors

	// Methods

	protected void GetPieces() {
        pieces.Clear();
        foreach(Piece p in board.pieces) {
            if(p.color == color) {
                pieces.Add(p);
            }
        }
    }

	protected void GetLegalMoves(){
        legalMoves.Clear();
        foreach (Move m in board.legalMoves) {
            if (m.blackTurn == color) {
                legalMoves.Add(m);
            }
        }
    }

    protected bool ToPlay() {
        return board.blackToPlay == color;
    }

}
