using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMono : MonoBehaviour {

	public Piece piece;

	public MoveManager moveManager;

	void OnMouseDown(){
		moveManager.SelectPiece (piece);
	}

}
