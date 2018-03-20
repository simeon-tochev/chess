using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour {

	[SerializeField] private GameObject squarePrefab;
	[SerializeField] private Vector2 startingCoordinates;

	[SerializeField] private Square square;

	private Board board = Board.STARTING_BOARD;

	private GameObject[,] squaresGO = new GameObject[8,8];
	private ArrayList piecesGO = new ArrayList();

	private MoveManager moveManager;

	private Player whitePlayer;
	private Player blackPlayer;

	private Vector2 squareSize;

	void Awake () {
		moveManager = GameObject.Find ("MoveManager").GetComponent<MoveManager> ();
		whitePlayer = GameObject.Find ("WhitePlayer").GetComponent<Player> ();
		blackPlayer = GameObject.Find ("BlackPlayer").GetComponent<Player> ();
		board.whitePlayer = whitePlayer;
		board.blackPlayer = blackPlayer;
		squareSize = squarePrefab.GetComponent<SpriteRenderer> ().bounds.size;
		DrawBoard ();
	}

	public void DrawBoard(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				squaresGO [j, i] = GameObject.Instantiate (squarePrefab, startingCoordinates + new Vector2(j*squareSize.x,i*squareSize.y), transform.rotation);
				squaresGO [j, i].GetComponent<SquareMono> ().square = board.squares [j, i];
				squaresGO [j, i].GetComponent<SquareMono> ().SetSquareMono ();
				if (squaresGO [j, i].GetComponent<SquareMono> ().square.isBlack) {
					squaresGO [j, i].GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.1f, 0.1f, 1);
				}
			}
		}
		foreach (Piece p in board.pieces) {
			GameObject pieceGO = GameObject.Instantiate (Resources.Load (p.pieceName), startingCoordinates + new Vector2 ((int)(p.col - 'A') * squareSize.x, (int)(p.row - '1') * squareSize.y), transform.rotation) as GameObject;
			pieceGO.GetComponent<PieceMono> ().moveManager = moveManager;
			pieceGO.GetComponent<PieceMono> ().piece = p;
			piecesGO.Add (pieceGO);
		}
	}
}
