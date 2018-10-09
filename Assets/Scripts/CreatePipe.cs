using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {

        Debug.Log("CreatePipe On mouse down");

    }

    void StartPipe(Vector3 initialPosition)
    {
        Debug.Log(initialPosition);
    }
}
