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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 MP = Input.mousePosition;



        //    if (MP.y <= ClickLimitHeight)
        //    {
        //        if (UserInMenu == false)
        //        {
        //            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            RaycastHit rhInfo;

        //            UserInMenu = false;

        //            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);

        //            if (didHit)
        //            {
        //                if (CurrentToolString == "Info")
        //                {
        //                    //Debug.Log(CurrentToolString + "   " + CurrentAssetString + "   " + CurrentTileString);
        //                    bool tileStatus = rhInfo.collider.gameObject.GetComponent<TileManager>().toggleStatus();
        //                    Debug.Log("Info tag clicked on " + rhInfo.collider.name + " is currently " + tileStatus);

        //                }
        //                else if (CurrentToolString=="Create Asset")
        //                {
        //                    Debug.Log("Create Asset of type " + CurrentAssetString);

        //                }
        //                else if (CurrentToolString=="Change Type")
        //                {
        //                    Debug.Log("Change Tile Type on tile " + rhInfo.collider.name);
        //                }
        //                //Debug.Log(CurrentToolString + "   " + CurrentAssetString + "   " + CurrentTileString);
        //                //Debug.Log(rhInfo.collider.name + "   " + rhInfo.point + "    " + MP);
        //            }
        //            else
        //            {
        //                //Debug.Log("Clicked Empty     " + MP);
        //            }
        //        }
        //        else
        //        {
        //            UserInMenu = false;
        //            Debug.Log("Exiting Menu     " + UserInMenu);
        //        }

        //    }
        //    else
        //    {

        //        UserInMenu = true;
        //        Debug.Log("Clicked Menu Bar   " + UserInMenu);
        //    }

        //}


    }
}
