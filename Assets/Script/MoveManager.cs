using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour {

	[SerializeField]
	Piece selectedPiece;

	[SerializeField]
	Square selectedSquare;

	public Board board;
	public BoardGenerator boardG;

	List<Move> selectedPieceLegalMoves = new List<Move>();
	ArrayList placedSquares = new ArrayList();

	[SerializeField]
	GameObject squarePrefab;

	bool blackTurn = false;

	public void SelectPiece(Piece p){
		print ("Succesfully selected " + p.pieceName);
		DeleteSquares ();
		selectedPiece = p;
        foreach(Move m in board.legalMoves) {
            if(m.pieceToMove == p) {
                selectedPieceLegalMoves.Add(m);
            }
        }

		foreach (Move sq in selectedPieceLegalMoves) {
			GameObject pieceGO = sq.movePoisition.squareMono.gameObject;
			GameObject greenSquare = GameObject.Instantiate (squarePrefab, pieceGO.transform.position + new Vector3(0f,0f,1f), pieceGO.transform.rotation) as GameObject;
			greenSquare.GetComponent<SpriteRenderer> ().color = Color.green;
			placedSquares.Add (greenSquare);
		}
	
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
			try {
				MakeMove (GetMove(selectedSquare));
			} 
			catch {
				print ("Invalid Move");
			}
		}
	}

	private Move GetMove(Square s){
		Move move = selectedPieceLegalMoves.Find (m => m.movePoisition.Equals (s));
		if (move) {
			return move;
		} else {
			return null;
		}
	}

	public void MakeMove(Move m){
		board = new Board (board, m);
		boardG.DrawBoard ();
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
