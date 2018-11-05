using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    public GameObject hexTilePrefab;

    public static int mapWidth = 100;
    public static int mapHeight = 100;
    public static float WaterLevel = 0.3f;
    public float NoiseScale;

    public int Octaves;
    [Range(0, 1)]
    public float Persistance;
    public float Lacunarity;

    public int Seed;
    public Vector2 Offset;

    public bool AutoUpdate;

    private float tileXOffset = 1.00f;
    private float tileYoffset = 0f;
    private float tileZoffset = 1.00f;


	// Use this for initialization
	void Start ()
    {
        CreateHexTileMap();
        CreateNoiseMap(mapWidth, mapHeight, Seed, NoiseScale, Octaves, Persistance, Lacunarity, Offset);
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
        GO.name = "T " + x.ToString() + "," + z.ToString();
    }



	// Update is called once per frame
	void Update () {
		
	}

    void CreateNoiseMap (int MapWidth, int MapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        Debug.Log("Create Noise Map");
        float[,] noiseMap = new float[MapWidth + 1, MapHeight + 1];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);

        }

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        for (int y=0; y < MapHeight + 1; y++)
        {
            for (int x = 0; x < MapWidth + 1; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;

                }

                noiseMap[x, y] = noiseHeight;

            }
        }
        for (int y = 0; y < MapHeight + 1; y++)
        {
            for (int x = 0; x < MapWidth + 1; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
                //Debug.Log(x + "       " + y + "        " + noiseMap[x,y]);
                string FindName = "T " + y.ToString() + "," + x.ToString();

                GameObject.Find(FindName).GetComponent<TileManager>().Height = noiseMap[x, y]; 
            }
        }
        Debug.Log("Finished Noise Map");
    }

    void OnValidate()
    {
        if (Lacunarity < 1)
        {
            Lacunarity = 1;
        }
        if (Octaves < 0)
        {
            Octaves = 0;
        }
    }
}
