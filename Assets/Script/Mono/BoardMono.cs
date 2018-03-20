using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMono : MonoBehaviour {

	public Board board = Board.STARTING_BOARD;

	public void SetPlayers(){
		board.whitePlayer = GameObject.Find ("WhitePlayer").GetComponent<Player> ();
		board.blackPlayer = GameObject.Find ("BlackPlayer").GetComponent<Player> ();
	}

}
