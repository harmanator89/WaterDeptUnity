using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour {


    private ClickAction clickAction;
    bool Started = false;
    bool status = true;
    public int CSHeight;
    public int CSWidth;
    public double ClickLimitHeight;
    public double ClickLimitWidth;
    public double PanelClickLimitHeight1;
    public double PanelClickLimitHeight2;
    public double PanelClickLimitWidth;
    public Material[] tileMaterials;
    public float Height;

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

    //private bool UserInMenu = false;

    public static Material CurrentType;

    private string NameSplit;
    private int FoundPosition;
    public float NameX;
    public float NameY;
    public float NameZ;

    private string PanelTitleText;

    MeshRenderer m_Renderer;

         
    // Use this for initialization
    void Start() {
        m_Renderer = GetComponent<MeshRenderer>();

        m_Renderer.material = tileMaterials[0];

        NameX = this.gameObject.transform.position.x;
        NameY = this.gameObject.transform.position.y;
        NameZ = this.gameObject.transform.position.z;

        NameSplit = this.name;

    }

    // Update is called once per frame
    void Update() {
        
        //Gets current screen dimensions
        CSHeight = Screen.height;
        CSWidth = Screen.width;

        //Excludes clicking on the tiles when click on the toolbar at the top
        ClickLimitHeight = CSHeight * 0.93;
        ClickLimitWidth = CSWidth * 0.95;
        PanelClickLimitHeight1 = CSHeight - 120;
        PanelClickLimitHeight2 = 70;
        PanelClickLimitWidth = 1585.4;

        if (Height <= HexTileMapGenerator.WaterLevel)
        {
            currentMaterial = 9;
            IsWater = true;
        }
        else
        {
            IsWater = false;
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
        Vector2 MP = Input.mousePosition;

        if (MP.y <= ClickLimitHeight)
        {
            if (ClickAction.UserInMenu == false)
            {
                //If in 'Info' mode, change tile being hovered over to 'selected' color
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
        //If in 'Info' mode, and mouse is leaving tile, change to normal color
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

        Vector2 MP = Input.mousePosition;

        if (MP.y > ClickLimitHeight)
        {
            //Mouse clicked in menu area
            Debug.Log("User clicked in menu area  " + MP.y);
            ClickAction.UserInMenu = true;
        }
        else
        {
            if (ClickAction.UserInMenu == true)
            {
                //User clicked off of menu after clicking on it
                Debug.Log("User clicked off menu area   ");
                ClickAction.UserInMenu = false;
            }
            else
            {
                if (ClickAction.ToolMode == 1)
                {
                    //Create Asset Mode
                    Debug.Log("Tile Manager Create Asset");
                }
                else if (ClickAction.ToolMode == 2)
                {
                    //Change Tile Type
                    if (ClickAction.TileMode == 0)
                    {
                        //Residential
                        currentMaterial = 4;
                        ClickAction.Funds -= ClickAction.ResidentialMeterCost;
                    }
                    else if (ClickAction.TileMode == 1)
                    {
                        //Commercial
                        currentMaterial = 2;
                        ClickAction.Funds -= ClickAction.CommercialMeterCost;

                    }
                    else if (ClickAction.TileMode == 2)
                    {
                        //Industrial
                        currentMaterial = 3;
                        ClickAction.Funds -= ClickAction.IndustrialMeterCost;

                    }
                    else if (ClickAction.TileMode == 3)
                    {
                        //Grass
                        currentMaterial = 0;
                        ClickAction.Funds -= ClickAction.GrassCost;

                    }
                    else if (ClickAction.TileMode == 4)
                    {
                        //Street
                        currentMaterial = 5;
                        ClickAction.Funds -= ClickAction.StreetCost;

                    }
                    else if (ClickAction.TileMode == 5)
                    {
                        //Water
                        currentMaterial = 9;
                        ClickAction.Funds -= ClickAction.WaterCost;

                    }
                }
                else if (ClickAction.ToolMode == 3)
                {
                    //Create Pipe Mode
                    Debug.Log("Tile Manager Create Pipe Mode");
                }
                else if (ClickAction.ToolMode == 0)
                {
                    //Info mode

                    if (MP.x >= PanelClickLimitWidth)
                    {
                        if(MP.y <= PanelClickLimitHeight1)
                        {
                            if(MP.y >= PanelClickLimitHeight2)
                            {
                                //Do nothing user is in panel
                            }
                            else
                            {
                                PanelTitleText = this.gameObject.name.ToString();
                                PanelTitleText = PanelTitleText.Remove(0, 2);
                                PanelTitleText = "Tile at " + PanelTitleText;
                                PanelManager.TitleText.text = PanelTitleText;
                            }
                        }
                        else
                        {
                            PanelTitleText = this.gameObject.name.ToString();
                            PanelTitleText = PanelTitleText.Remove(0, 2);
                            PanelTitleText = "Tile at " + PanelTitleText;
                            PanelManager.TitleText.text = PanelTitleText;
                        }
                    }
                    else
                    {
                        PanelTitleText = this.gameObject.name.ToString();
                        PanelTitleText = PanelTitleText.Remove(0, 2);
                        PanelTitleText = "Tile at " + PanelTitleText;
                        PanelManager.TitleText.text = PanelTitleText;
                        Debug.Log(PanelClickLimitHeight1 + " > " + MP.y + " > " + PanelClickLimitHeight2 + " / " + PanelClickLimitWidth + " > " + MP.x);
                        //ClickAction.PanelToggle = true;

                        //Debug.Log(this.gameObject.name + "      " + Height);
                    }

                }
                else if (ClickAction.ToolMode == 4)
                {
                    //None Mode
                    Debug.Log(ClickAction.UserInMenu + "   " + MP.y + "   " + ClickLimitHeight);
                }
                else
                {
                    Debug.Log("Tool Mode not configured correctly.");
                }
            }
        }


    }
    public bool ToggleStatus()
    {
        status = !status;
        return status;
    }




}
