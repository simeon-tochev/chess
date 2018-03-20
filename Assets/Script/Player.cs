using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private bool color;

	public ArrayList pieces = new ArrayList();
	public List<Move> legalMoves = new List<Move> ();

	// Constructors

	public Player(){
	}

	// Methods

	public void AddPiece(Piece p){
		pieces.Add (p);
	}

	public void RemovePiece(Piece p){
		pieces.Remove (p);
	}

	public List<Move> GetLegalMoves(){
		return legalMoves;
	}

	public void ClearLegalMoves(){
		legalMoves.Clear ();
	}

	public void AddLegalMoves(){
		foreach (Piece p in pieces) {
			foreach (Move m in p.legalMoves) {
				legalMoves.Add (m);
			}
		}
	}

}
