using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour {

    Vector3 ClickedTileName;
    Object ClickedGameObject;
    
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(ClickedGameObject);
            //print("Mouse Click 0");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
