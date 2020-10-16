using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMono : MonoBehaviour {

	public Piece piece;

	public MoveManager moveManager;

    private void Start() {
        moveManager = GameObject.Find("MoveManager").GetComponent<MoveManager>();
    }

    void OnMouseDown(){
        print("Clicked on: " + piece.pieceName);
		moveManager.SelectPiece (piece);
	}

}
