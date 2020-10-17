using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text gameState;

    private void Start() {
        boardG = GameObject.Find("BoardGenerator").GetComponent<BoardGenerator>();
        board = boardG.board;
        gameState = GameObject.Find("GameState").GetComponent<Text>();
    }

    public void SelectPiece(Piece p){
	//	print ("Succesfully selected " + p.pieceName);
		DeleteSquares ();
        selectedPieceLegalMoves.Clear();
        selectedPiece = p;
        foreach(Move m in board.legalMoves) {
            if(board.FindPieceOnBoard(m.colFrom,m.rowFrom) == p) {
                selectedPieceLegalMoves.Add(m);
            }
        }

		foreach (Move sq in selectedPieceLegalMoves) {
            Square s = board.GetSquare(sq.colTo - 'A', sq.rowTo - '1');
            GameObject squareTo = s.squareMono.gameObject;
			GameObject greenSquare = Instantiate (squarePrefab, squareTo.transform.position + new Vector3(0f,0f,-2f), squareTo.transform.rotation) as GameObject;
			greenSquare.GetComponent<SpriteRenderer> ().color = Color.green;
            greenSquare.GetComponent<SquareMono>().square = s;

			placedSquares.Add (greenSquare);
		}
	
	}

	public void DeselectPiece(){
		selectedPiece = null;
		selectedSquare = null;
		DeleteSquares ();
	}

	public void SelectSquare(Square s){
        //	print ("Selected Square: " + s.col.ToString() + s.row.ToString());
        if (selectedPiece != null) {
			selectedSquare = s;
			try {
                Move m = GetMove(selectedSquare);
            //   print(m.colTo.ToString() + m.rowTo.ToString());
                MakeMove(m);
            //    print(board.ToString());
			} 
			catch (Exception e) {
                print(e.ToString());
                DeselectPiece();
				print ("Invalid Move");
			}
		}
	}

	private Move GetMove(Square s){
		Move move = selectedPieceLegalMoves.Find (m => s == board.GetSquare(m.colTo - 'A', m.rowTo - '1'));
        if (move != null) {
			return move;
		} else {
			return null;

		}
	}

	public void MakeMove(Move m){
        board.MakeMove(m);
        DeselectPiece();
        boardG.DrawPieces();
        
        switch (board.gameState) {
            case '1': gameState.text = ""; break;
            case '2': gameState.text = "Black Checkmated"; break;
            case '3': gameState.text = "White Checkmated"; break;
            case '4': gameState.text = "Black Resigned"; break;
            case '5': gameState.text = "White Resigned"; break;
            case '6': gameState.text = "Black Stalemated"; break;
            case '7': gameState.text = "White Stalemated"; break;
            case '8': gameState.text = "Draw"; break;

        }
    }

	private void DeleteSquares(){
		foreach (GameObject sq in placedSquares) {
			GameObject.Destroy (sq);
		}
	}

	public bool GetTurn(){
		return blackTurn ;
	}

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)){
            print(board.ToString());
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            foreach(Piece p in board.pieces) {
                print(p.pieceName + " at " + p.position.col.ToString() + p.position.row.ToString());
            }
        }
    }

}
