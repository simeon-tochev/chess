using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private bool color;

	public ArrayList pieces = new ArrayList();
	public List<Move> legalMoves = new List<Move> ();

    public Board board;

    private void Start() {
        board = GameObject.Find("BoardGenerator").GetComponent<BoardGenerator>().board;
    }

    // Constructors

    public Player(bool color) {
        this.color = color;
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

	}

}
