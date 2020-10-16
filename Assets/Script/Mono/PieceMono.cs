using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMono : MonoBehaviour {

	public Piece piece;

	public MoveManager moveManager;

    public char col;
    public char row;
    public string name;

    private void Start() {
        moveManager = GameObject.Find("MoveManager").GetComponent<MoveManager>();
    }

    void OnMouseDown(){
		moveManager.SelectPiece (piece);
	}

    private void Update() {
        col = piece.col;
        row = piece.row;
        name = piece.pieceName;
    }

}
