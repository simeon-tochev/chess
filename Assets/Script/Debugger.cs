using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

////	Debugged stuff

//	Accessing Square neighbors should work fine
//  Piece legal move calculation
//  

	[SerializeField]
	GameObject somePieceGO;

	[SerializeField]
	Piece somePiece;

	Board board;

	ArrayList ar;

	void Start () {
//		board = GameObject.Find ("Board").GetComponent<Board>();
//		somePieceGO = GameObject.Find ("Rook_White(Clone)");
//		somePiece = somePieceGO.GetComponent<Piece> ();
//		somePiece.CalculateLegalMoves ();
//		ar = somePiece.GetLegalMoves ();
//		foreach (Square sq in ar) {
//			
//		}
	}

	void Update () {
		
	}
}
