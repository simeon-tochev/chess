using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMono : MonoBehaviour {

	public Square square;

	public void SetSquareMono(){
		square.squareMono = this;
	}

	void OnMouseDown(){
	//	moveManager.SelectSquare (square);
	}

}
