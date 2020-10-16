using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMono : MonoBehaviour {

	public Square square;
    public MoveManager moveManager;

    private void Start() {
        moveManager = GameObject.Find("MoveManager").GetComponent<MoveManager>();
    }

    public void SetSquareMono(){
		square.squareMono = this;
	}

	void OnMouseDown(){
        moveManager.SelectSquare(square);
	}

}
