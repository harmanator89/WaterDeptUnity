using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;

    public int mapWidth = 25;
    public int mapHeight = 12;

    public float tileXOffset = 1.8f;
    public float tileYoffset = 0f;
    public float tileZoffset = 1.565f;


	// Use this for initialization
	void Start ()
    {
        CreateHexTileMap();
	}
	
    void CreateHexTileMap ()
    {
        for(int x = 0; x <= mapWidth; x++)
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
                    TempGO.transform.position = new Vector3(x * tileXOffset + tileXOffset / 2, y * tileYoffset, z * tileZoffset);
                }

                //calls SetTileInfo
                SetTileInfo(TempGO, x, y, z);
            }
        }

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
            //print("Mouse Click 0");
        }
    }

    void SetTileInfo(GameObject GO, int x, int y, int z)
    {

        GO.transform.parent = transform;
        GO.name = x.ToString() + ", " + z.ToString() + ", " + y.ToString(); 
    }



	// Update is called once per frame
	void Update () {
		
	}
}
