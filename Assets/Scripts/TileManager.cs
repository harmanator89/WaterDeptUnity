﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


    private ClickAction clickAction;
    bool Started = false;
    bool status = true;
    public Material[] tileMaterials;

    public int currentMaterial;
    public int newMaterial;
    public int RandomStartMaterial;
    public int RandomWater;
    public int WaterChance;

    public string FindName;
    public float FindNameX;
    public float FindNameZ;
    public bool FindGameObject;

    public bool LeftWater;
    public bool RightWater;
    public bool TopWater;
    public bool BottomWater;

    public GameObject NewAsset;
    public bool TileSelected;
    public bool IsWater;
    public bool Occupied;

    private bool UserInMenu = false;

    public static Material CurrentType;

    private string NameSplit;
    private int FoundPosition;
    public float NameX;
    public float NameY;
    public float NameZ;


    MeshRenderer m_Renderer;

         
    // Use this for initialization
    void Start() {
        m_Renderer = GetComponent<MeshRenderer>();
        //Gives each tile a random material
        //RandomStartMaterial = Random.Range(0, 6);
        //if (RandomStartMaterial == 1)
        //{
        //    RandomStartMaterial = 0;
        //}
        ////Debug.Log(RandomStartMaterial);
        m_Renderer.material = tileMaterials[0];

        NameX = this.gameObject.transform.position.x;
        NameY = this.gameObject.transform.position.y;
        NameZ = this.gameObject.transform.position.z;

        NameSplit = this.name;

        //Debug.Log(NameSplit + "      " + NameX + "       " + NameZ);

    }

    // Update is called once per frame
    void Update() {
        
        // If first time running, and MapWaterTileTotal has water tiles still available
        if (Started == false)
        {
            if (this.name == "40,30")
            {
                currentMaterial = 9;
                IsWater = true;
            }
            //if (ClickAction.MapWaterTileTotal >= 0)
            //{
            //    //If nearby is water ==> higher chance of water
            //    RandomWater = Random.Range(0, 200);

            //    for (int i = 0; i <= 1; i++)
            //    {
            //        for (int j = 0; j <= 1; j++)
            //        {
            //            FindNameX = NameX + 1 - (i*2);
            //            FindNameZ = NameZ + 1 - (j * 2);

            //            if (FindNameX >= 0 && FindNameX <= HexTileMapGenerator.mapWidth)
            //            {
            //                if (FindNameZ >= 0 && FindNameZ <= HexTileMapGenerator.mapHeight)
            //                {
            //                    FindName = FindNameX + "," + FindNameZ;



            //                    FindGameObject = GameObject.Find(FindName).GetComponent<TileManager>().IsWater;
            //                    if (FindGameObject == true)
            //                    {
            //                        WaterChance += 50;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    //WaterChance += 10;

            //    //Debug.Log(this.name + "    " + WaterChance);

            //    if (RandomWater <= WaterChance)
            //    {
            //        currentMaterial = 9;
            //        IsWater = true;
            //        ClickAction.MapWaterTileTotal -= 1;
            //    }

            //}
            //if (ClickAction.MapWaterTileTotal <= 2)
            //{
                Started = true;
            //}

        }




        if (currentMaterial == 0)
        {
            m_Renderer.material = tileMaterials[0];
            IsWater = false;
        }
        else if (currentMaterial == 1)
        {
            m_Renderer.material = tileMaterials[1];
            IsWater = false;
        }
        else if (currentMaterial == 2)
        {
            m_Renderer.material = tileMaterials[2];
            IsWater = false;
        }
        else if (currentMaterial == 3)
        {
            m_Renderer.material = tileMaterials[3];
            IsWater = false;
        }
        else if (currentMaterial == 4)
        {
            m_Renderer.material = tileMaterials[4];
            IsWater = false;
        }
        else if (currentMaterial == 5)
        {
            m_Renderer.material = tileMaterials[5];
            IsWater = false;
        }
        else if (currentMaterial == 6)
        {
            m_Renderer.material = tileMaterials[6];
            IsWater = false;
        }
        else if (currentMaterial == 7)
        {
            m_Renderer.material = tileMaterials[7];
            IsWater = false;
        }
        else if (currentMaterial == 8)
        {
            m_Renderer.material = tileMaterials[8];
            IsWater = false;
        }
        else if (currentMaterial == 9)
        {
            m_Renderer.material = tileMaterials[9];
            IsWater = true;
        }
    }

    void OnMouseOver()
    {
        //Gets current screen dimensions
        int CSHeight = Screen.height;
        int CSWidth = Screen.width;

        //Excludes clicking on the tiles when click on the toolbar at the top
        double ClickLimitHeight = CSHeight * 0.93;
        //double ClickLimithWidth = CSWidth * 0.95;

        Vector2 MP = Input.mousePosition;

        if (MP.y <= ClickLimitHeight)
        {
            if (UserInMenu == false)
            {
                if (ClickAction.ToolMode == 0)
                {
                    if (currentMaterial == 0)
                    {
                        currentMaterial = 1;


                    }
                    else if (currentMaterial == 2)
                    {
                        currentMaterial = 6;
                    }
                    else if (currentMaterial == 3)
                    {
                        currentMaterial = 7;

                    }
                    else if (currentMaterial == 4)
                    {
                        currentMaterial = 8;

                    }

                }
            }
            else
            {

            }
        }
    }
    void OnMouseExit()
    {
        if (ClickAction.ToolMode == 0)
        {
            if (currentMaterial == 1)
            {
                currentMaterial = 0;

            }
            else if (currentMaterial == 6)
            {
                currentMaterial = 2;

            }
            else if (currentMaterial == 7)
            {
                currentMaterial = 3;

            }
            else if (currentMaterial == 8)
            {
                currentMaterial = 4;

            }
        }
    }
    void OnMouseDown()
    {
        //Gets current screen dimensions
        int CSHeight = Screen.height;
        int CSWidth = Screen.width;

        //Excludes clicking on the tiles when click on the toolbar at the top
        double ClickLimitHeight = CSHeight * 0.95;
        //double ClickLimithWidth = CSWidth * 0.95;

        Vector2 MP = Input.mousePosition;

        if (MP.y <= ClickLimitHeight)
        {
            if (UserInMenu == false)
            {
                if (ClickAction.ToolMode == 1)
                {
                    //Create Asset
                    Debug.Log("Tile Manager Create Asset");

                    if (ClickAction.AssetMode == 0)
                    {
                        //Tank
                    }
                    else if(ClickAction.AssetMode== 1)
                    {
                        //Pump
                    }
                    else if (ClickAction.AssetMode == 2)
                    {
                        //PRV
                    }
                    else if (ClickAction.AssetMode == 3)
                    {
                        //Valve
                    }


                    //AssetPlacement.SetItem()
                }
                else if (ClickAction.ToolMode == 2)
                {
                    //Change Tile Type
                    if (ClickAction.TileMode == 0)
                    {
                        //Residential
                        currentMaterial = 4;
                    }
                    else if (ClickAction.TileMode == 1)
                    {
                        //Commercial
                        currentMaterial = 2;
                    }
                    else if (ClickAction.TileMode == 2)
                    {
                        //Industrial
                        currentMaterial = 3;
                    }
                    else if (ClickAction.TileMode == 3)
                    {
                        //Grass
                        currentMaterial = 0;
                    }
                    else if (ClickAction.TileMode == 4)
                    {
                        //Street
                        currentMaterial = 5;
                    }
                    else if (ClickAction.TileMode == 5)
                    {
                        //Water
                        currentMaterial = 9;
                    }
                }
                else if (ClickAction.ToolMode == 3)
                {
                    //Create Pipe Mode

                    Debug.Log("Tile Manager On-Click");
                    
                    //Vector3 PassTileCoord;
                    //PassTileCoord = this.gameObject.transform.position;

                }
                else if (ClickAction.ToolMode == 0)
                {
                    //Info mode
                    Debug.Log(this.gameObject.name + "      " + WaterChance);
                }
                else
                {
                    Debug.Log("Tool Mode not configured correctly.");
                }
            }
            else

            {
                UserInMenu = false;
                Debug.Log("Exiting Menu     " + UserInMenu);
            }
        }
        else
        {

            UserInMenu = true;
            Debug.Log("Clicked Menu Bar   " + UserInMenu);
        }
    }
    public bool toggleStatus()
    {
        status = !status;
        return status;
    }




}
