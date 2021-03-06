using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour {

	[SerializeField] private GameObject squarePrefab;
	[SerializeField] private Vector3 startingCoordinates;

	[SerializeField] private Square square;

    public Board board;

	public GameObject[,] squaresGO = new GameObject[8,8];
	private ArrayList piecesGO = new ArrayList();

	private MoveManager moveManager;

	private Player whitePlayer;
	private Player blackPlayer;

	private Vector2 squareSize;

	void Awake () {
        board = Board.STARTING_BOARD;
        //board = new Board();
        moveManager = GameObject.Find ("MoveManager").GetComponent<MoveManager> ();
        // whitePlayer = board.whitePlayer;
        // blackPlayer = board.blackPlayer;
		// board.whitePlayer = whitePlayer;
		// board.blackPlayer = blackPlayer;
		squareSize = squarePrefab.GetComponent<SpriteRenderer> ().bounds.size;
        
		DrawBoard ();

        //print(board.FindPieceOnBoard('A', '1').pieceName);

        foreach(Move m in board.legalMoves) {
         //   print(board.FindPieceOnBoard(m.colFrom, m.rowFrom).pieceName + " to " + m.colTo.ToString() + m.rowTo.ToString());
        }

        foreach(Square s in board.squares) {
            if (s.isOccupied()) {
             //   print(s.col.ToString() + s.row.ToString() + " : " + s.GetOccupant().pieceName);
            }
        }

        foreach (Piece p in board.pieces) {
         //   print(p.pieceName + " at: " + p.col.ToString() + p.row.ToString());
        }

    }

    public void DrawBoard(){
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				squaresGO [j, i] = Instantiate (squarePrefab, startingCoordinates + new Vector3 (j*squareSize.x,i*squareSize.y,0), transform.rotation);
				squaresGO [j, i].GetComponent<SquareMono> ().square = board.squares [j, i];
				squaresGO [j, i].GetComponent<SquareMono> ().SetSquareMono ();
				if (squaresGO [j, i].GetComponent<SquareMono> ().square.isBlack) {
					squaresGO [j, i].GetComponent<SpriteRenderer> ().color = new Color (0.5f, 0.1f, 0.1f, 1);
				}
			}
		}

        DrawPieces();
		
	}

    public void DrawPieces() {
        foreach(GameObject pGO in piecesGO) {
            Destroy(pGO);
        }
        foreach (Piece p in board.pieces) {
            GameObject pieceGO = Instantiate(Resources.Load(p.pieceName), startingCoordinates + new Vector3((int)(p.col - 'A') * squareSize.x, (int)(p.row - '1') * squareSize.y, -1), transform.rotation) as GameObject;
            pieceGO.GetComponent<PieceMono>().moveManager = moveManager;
            pieceGO.GetComponent<PieceMono>().piece = p;
            piecesGO.Add(pieceGO);
        }
    }
}


