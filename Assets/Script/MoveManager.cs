using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

	[SerializeField]
	Piece selectedPiece;

	[SerializeField]
	Square selectedSquare;

	ArrayList selectedPieceLegalMoves;
	ArrayList placedSquares = new ArrayList();

	[SerializeField]
	GameObject squarePrefab;

	bool blackTurn = false;

	public void SelectPiece(Piece p){
	/*
		DeleteSquares ();
		selectedPiece = p;
		selectedPieceLegalMoves = p.GetLegalMoves ();
		foreach (Square sq in selectedPieceLegalMoves) {
			GameObject pieceGO = sq.gameObject;
			GameObject greenSquare = GameObject.Instantiate (squarePrefab, pieceGO.transform.position + new Vector3(0f,0f,1f), pieceGO.transform.rotation) as GameObject;
			greenSquare.GetComponent<SpriteRenderer> ().color = Color.green;
			placedSquares.Add (greenSquare);
		}
	*/
	}

	public void DeselectPiece(){
		selectedPiece = null;
		selectedSquare = null;
		DeleteSquares ();
	}

	public void SelectSquare(Square s){
		print ("Selected Square");
		if (!selectedPiece.Equals(null)) {
			selectedSquare = s;
			MakeMove (selectedPiece, selectedSquare);
		}
	}

	public void MakeMove(Piece p, Square s){
	/*	if(p.GetLegalMoves().Contains(s)){
			DeleteSquares ();
			p.Move(s);
			blackTurn = !blackTurn;
		} else {
			DeselectPiece ();
		}
	*/
	}

	private void DeleteSquares(){
		foreach (GameObject sq in placedSquares) {
			GameObject.Destroy (sq);
		}
	}

	public bool GetTurn(){
		return blackTurn ;
	}

}
