﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;

    public static int mapWidth = 100;
    public static int mapHeight = 100;


    //1.8, 0, 1.565
    private float tileXOffset = 1.00f;
    private float tileYoffset = 0f;
    private float tileZoffset = 1.00f;


	// Use this for initialization
	void Start ()
    {
        CreateHexTileMap();
        CreateNoiseMap();

	}
	
    void CreateHexTileMap ()
    {
        ClickAction.MapWaterTileTotal = mapHeight * mapWidth * ClickAction.MapWaterPercentage;

        for (int x = 0; x <= mapWidth; x++)
        {
            for(int z = 0; z <= mapHeight; z++)
            {
                GameObject TempGO = Instantiate(hexTilePrefab);

                int y = 0;


                // Moves every even tile to 1st row, and the odd row to the 2nd row, etc
                if (z % 2 == 0)
                {
                    TempGO.transform.position = new Vector3(x * tileXOffset, y* tileYoffset, z * tileZoffset);
                }
                else
                {
                    TempGO.transform.position = new Vector3(x * tileXOffset, y * tileYoffset, z * tileZoffset);
                }

                //calls SetTileInfo
                
                SetTileInfo(TempGO, x, y, z);
            }
        }
        Debug.Log("Finished Tile Map");

    }


    void SetTileInfo(GameObject GO, int x, int y, int z)
    {
        GO.transform.parent = transform;

        // Full Name
        //GO.name = x.ToString() + ", " + y.ToString() + ", " + z.ToString();

        //Partial Name
        GO.name = x.ToString() + "," + z.ToString();
    }



	// Update is called once per frame
	void Update () {
		
	}

    void CreateNoiseMap ()
    {
        Debug.Log("Create Noise Map");
    }
}
