using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickAction : MonoBehaviour {


    private TileManager tileManager;

    string CurrentToolString;
    string CurrentAssetString;
    string CurrentTileString;

    //Sub in Linked lists (grouped by network). Instead of updating whole network
    //only update the list the new node is on.

    public int PipeCount;
    public static int PipeUpdatedCount;
    public int NodeCount;
    public static int NodeUpdateCount;
    public static bool UpdateNetwork;


    public static int ToolMode;
    public static int AssetMode;
    public static int TileMode;

    public static float MapWaterPercentage = 0.3f;
    public static float MapWaterTileTotal;

    public static int Funds;
    public static int CommercialCustomers;
    public static int ResidentialCustomers;
    public static int IndustrialCustomers;

    public static bool PanelToggle;
    public GameObject infoPanel;


    // Use this for initialization
    void Start () {
        
        //Change on Game Difficultly

        Funds = 100000;

        infoPanel = GameObject.Find("Panel");
        PanelToggle = false;

    }
	
	// Update is called once per frame
	void Update () {


        //Gets current Text in dropdowns on Toolbar
        Dropdown CurrentToolMode = GameObject.Find("ToolMode").GetComponent<Dropdown>();
        string CurrentToolString = CurrentToolMode.captionText.text;

        Dropdown CurrentAssetMode = GameObject.Find("NewAsset").GetComponent<Dropdown>();
        string CurrentAssetString = CurrentAssetMode.captionText.text;

        Dropdown CurrentTileMode = GameObject.Find("TileType").GetComponent<Dropdown>();
        string CurrentTileString = CurrentTileMode.captionText.text;


        if (CurrentToolString == "Info")
        {
            ToolMode = 0;

            PanelToggle = true;
            infoPanel.SetActive(true);
        }
        else if (CurrentToolString =="Create Asset")
        {
            ToolMode = 1;

            PanelToggle = false;
            infoPanel.SetActive(false);
            //Debug.Log("Panel False");
        }
        else if (CurrentToolString =="Change Type")
        {
            ToolMode = 2;

            PanelToggle = false;
            infoPanel.SetActive(false);
        }
        else if (CurrentToolString == "Create Pipe")
        {
            ToolMode = 3;

            PanelToggle = false;
            infoPanel.SetActive(false);
        }
        
        //Debug.Log(ToolMode + "  " + CurrentToolString);

        if (CurrentAssetString == "Tank")
        {
            AssetMode = 0;
        }
        else if (CurrentAssetString == "Pump")
        {
            AssetMode = 1;
        }
        else if (CurrentAssetString == "PRV")
        {
            AssetMode = 2;
        }
        else if (CurrentAssetString == "Valve")
        {
            AssetMode = 3;
        }
        else if (CurrentAssetString == "Water Treatment")
        {
            AssetMode = 5;
        }




        if (CurrentTileString == "Residential")
        {
            TileMode = 0;
        }
        else if (CurrentTileString == "Commercial")
        {
            TileMode = 1;
        }
        else if (CurrentTileString == "Industrial")
        {
            TileMode = 2;
        }
        else if (CurrentTileString == "Grass")
        {
            TileMode = 3;
        }
        else if (CurrentTileString == "Street")
        {
            TileMode = 4;
        }
        else if (CurrentTileString == "Water")
        {
            TileMode = 5;
        }


        if (PipeCount >= PipeUpdatedCount || NodeCount >= NodeUpdateCount)
        {

            UpdateNetwork = true;

        }
        else
        {
            UpdateNetwork = false;
        }

    }

    //void StartPipe(Vector3 initialPoint)
    //{
    //    Debug.Log(initialPoint);
    //}
}
