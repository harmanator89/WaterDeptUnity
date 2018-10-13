using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody rb;
    public float Speed;
    public Vector3 initialization;
    private float mapTiledHeight;
    private float mapTiledWidth;

    public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;
    private Camera myCamera;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
       // myCamera = GetComponent<Camera>();
        myCamera = this.GetComponentInChildren<Camera>();

        //rb.MovePosition(initialization);

        float Height = HexTileMapGenerator.mapHeight;
        float Width = HexTileMapGenerator.mapWidth;

        //fovMin = 20;
        //fovMax = 50;

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
        if (myCamera.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                myCamera.orthographicSize += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                myCamera.orthographicSize -= zoomSpeed;
            }
            myCamera.orthographicSize = Mathf.Clamp(myCamera.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                myCamera.fieldOfView += zoomSpeed;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                myCamera.fieldOfView -= zoomSpeed;
            }
            myCamera.fieldOfView = Mathf.Clamp(myCamera.fieldOfView, fovMin, fovMax);
        }
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
