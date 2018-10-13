using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickAction : MonoBehaviour {


    private TileManager tileManager;

    string CurrentToolString;
    string CurrentAssetString;
    string CurrentTileString;


    public static int ToolMode;
    public static int AssetMode;
    public static int TileMode;

    public static float MapWaterPercentage = 0.3f;
    public static float MapWaterTileTotal;

    public static int CommercialCustomers;
    public static int ResidentialCustomers;
    public static int IndustrialCustomers;





    // Use this for initialization
    void Start () {

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
        }
        else if (CurrentToolString =="Create Asset")
        {
            ToolMode = 1;
        }
        else if (CurrentToolString =="Change Type")
        {
            ToolMode = 2;
        }
        else if (CurrentToolString == "Create Pipe")
        {
            ToolMode = 3;
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
    }

    void StartPipe(Vector3 initialPoint)
    {
        Debug.Log(initialPoint);
    }
}
