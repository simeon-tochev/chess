using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    BoardGenerator boardGenerator;
    // Start is called before the first frame update
    void Start()
    {
        boardGenerator = GameObject.Find("BoardGenerator").GetComponent<BoardGenerator>();
        transform.position = boardGenerator.squaresGO[3, 3].transform.position - new Vector3(0,0,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
