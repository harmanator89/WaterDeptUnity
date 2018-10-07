using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public Vector3 initialization;
    private float mapTiledHeight;
    private float mapTiledWidth;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //rb.MovePosition(initialization);

        float Height = GameObject.Find("TileGenerator").GetComponent<HexTileMapGenerator>().mapHeight;
        float Width = GameObject.Find("TileGenerator").GetComponent<HexTileMapGenerator>().mapWidth;

        mapTiledHeight = Height * 0.5f;
        mapTiledWidth = Width * 0.5f;

        Debug.Log(mapTiledHeight + "  " + mapTiledWidth);
        Vector3 StartPosition = new Vector3(mapTiledWidth, 1, mapTiledHeight);
        InitializePlayer(StartPosition);
    }
	
    void InitializePlayer(Vector3 StartPostion)
    {
        rb.MovePosition(StartPostion);
        return;
    }

	// Update is called once per frame
	void Update () {
		
	}

    //physics code
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.transform.Translate(movement*Speed);
            

    }
}
