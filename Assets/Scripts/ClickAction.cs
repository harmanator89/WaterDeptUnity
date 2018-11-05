using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickAction : MonoBehaviour {

    //THIS IS THE GAME CONTROLLER.


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
    public static int ResidentialMeterCost;
    public static int CommercialMeterCost;
    public static int IndustrialMeterCost;
    public static int GrassCost;
    public static int StreetCost;
    public static int WaterCost;
    
    public static int CommercialCustomers;
    public static int ResidentialCustomers;
    public static int IndustrialCustomers;

    public static bool PanelToggle;
    public GameObject infoPanel;

    public GameObject ChangeTextbox;
    public GameObject ChangeDropdown;
    public GameObject AssetTextbox;
    public GameObject AssetDropdown;
    public Dropdown CurrentToolMode;
    public Dropdown CurrentTileMode;
    public Dropdown CurrentAssetMode;

    public static bool UserInMenu;

    // Use this for initialization
    void Start () {

        //Stores Panel, then sets inactive
        infoPanel = GameObject.Find("Panel");
        PanelToggle = false;


        //Stores dropdowns
        ChangeTextbox = GameObject.Find("ChangeTileTypeText");
        ChangeDropdown = GameObject.Find("TileType");
        AssetTextbox = GameObject.Find("NewAssetText");
        AssetDropdown = GameObject.Find("NewAsset");
        

        //Gets current Text in dropdowns on Toolbar
        CurrentToolMode = GameObject.Find("ToolMode").GetComponent<Dropdown>();
        string CurrentToolString = CurrentToolMode.captionText.text;

        CurrentAssetMode = GameObject.Find("NewAsset").GetComponent<Dropdown>();
        string CurrentAssetString = CurrentAssetMode.captionText.text;

        CurrentTileMode = GameObject.Find("TileType").GetComponent<Dropdown>();
        string CurrentTileString = CurrentTileMode.captionText.text;

        //Change on Game Difficultly
        Funds = 100000;
        Debug.Log("Starting funds = " + Funds);

        FundsManager.FundsText = "Current Funds = $" + Funds.ToString();

        ResidentialMeterCost = 400;
        CommercialMeterCost = 1000;
        IndustrialMeterCost = 2000;
        GrassCost = 100;
        StreetCost = 100;
        WaterCost = 50;
        Debug.Log(ResidentialCustomers + "  " + CommercialCustomers + "  " + IndustrialCustomers);

        //Sets boxes inactive
        ChangeTextbox.SetActive(false);
        ChangeDropdown.SetActive(false);
        AssetTextbox.SetActive(false);
        AssetDropdown.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        
        //Gets current toolmode in dropdown
        CurrentToolString = CurrentToolMode.captionText.text;
        
        //Gets current AssetMode in dropdown
        CurrentAssetString = CurrentAssetMode.captionText.text;

        //Gets current TileMode in dropdown
        CurrentTileString = CurrentTileMode.captionText.text;




        //Updates Funds
        FundsManager.FundsText = "Current Funds = $" + Funds.ToString();

        if (CurrentToolString == "Info")
        {
            ToolMode = 0;

            PanelToggle = true;
            infoPanel.SetActive(true);
            ChangeTextbox.SetActive(false);
            ChangeDropdown.SetActive(false);
            AssetTextbox.SetActive(false);
            AssetDropdown.SetActive(false);
        }
        else if (CurrentToolString =="Create Asset")
        {
            ToolMode = 1;

            PanelToggle = false;
            infoPanel.SetActive(false);
            ChangeTextbox.SetActive(false);
            ChangeDropdown.SetActive(false);
            AssetTextbox.SetActive(true);
            AssetDropdown.SetActive(true);

            //Debug.Log("Panel False");
        }
        else if (CurrentToolString =="Change Type")
        {
            ToolMode = 2;

            PanelToggle = false;
            infoPanel.SetActive(false);
            ChangeTextbox.SetActive(true);
            ChangeDropdown.SetActive(true);
            AssetTextbox.SetActive(false);
            AssetDropdown.SetActive(false);

        }
        else if (CurrentToolString == "Create Pipe")
        {
            ToolMode = 3;

            PanelToggle = false;
            infoPanel.SetActive(false);
            ChangeTextbox.SetActive(false);
            ChangeDropdown.SetActive(false);
            AssetTextbox.SetActive(false);
            AssetDropdown.SetActive(false);
        }
        else if (CurrentToolString == "None")
        {
            ToolMode = 4;

            PanelToggle = false;
            infoPanel.SetActive(false);
            ChangeTextbox.SetActive(false);
            ChangeDropdown.SetActive(false);
            AssetTextbox.SetActive(false);
            AssetDropdown.SetActive(false);

        }
        
        //Debug.Log(CurrentToolString + "  " + CurrentAssetString + "   " + CurrentTileString);

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
