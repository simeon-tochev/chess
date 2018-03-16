using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private bool color;

	private ArrayList pieces = new ArrayList();
	private ArrayList legalMoves = new ArrayList();

	public void AddPiece(Piece p){
		pieces.Add (p);
	}

	public void RemovePiece(Piece p){
		pieces.Remove (p);
	}

	public ArrayList GetLegalMoves(){
		return legalMoves;
	}

	public void ClearLegalMoves(){
		legalMoves.Clear ();
	}

	public void AddLegalMoves(){
		foreach (Piece p in pieces) {
			foreach (Square s in p.legalMoves) {
				legalMoves.Add (s);
			}
		}
	}

}
