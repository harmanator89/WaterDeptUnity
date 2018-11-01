using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

    private string NodeNameFirst;
    private string NodeNameLast;
    private string FindTileName;
    private int FindChar;

    public Material[] NodeMaterials;
    public GameObject[] ConnectedPipes;

    private bool PlacedOnWaterTile;
    private bool placed = false;
    public bool IsRawWater = false;
    public bool IsFinishWater = false;

    private string PanelTitleText;

    MeshRenderer m_Renderer;

    // Use this for initialization
    void Start () {

        //FindChar = this.name.IndexOf(@",");
        //FindTileName = 

        //Debug.Log(FindChar);
        m_Renderer = GetComponent<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        if (ClickAction.UpdateNetwork == true)
        {
            // Check connected pipes
            //Debug.Log("Updating " + this.name);
            ClickAction.NodeUpdateCount += 1;
        }

        if (placed == false)
        {
            FindChar = this.name.IndexOf(@",");

            if (FindChar == -1)
            {

            }
            else
            {
                //Debug.Log(FindChar);
                NodeNameFirst = "T " + this.gameObject.name;
                PlacedOnWaterTile = GameObject.Find(NodeNameFirst).GetComponent<TileManager>().IsWater;
                placed = true;
            }
        }

        if (placed == true)
        {
            if (PlacedOnWaterTile == true)
            {
                //this.gameObject.GetComponent;
                IsRawWater = true;
                m_Renderer.material = NodeMaterials[1];

            }




        }

    }

    void OnMouseDown()
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
            //if (UserInMenu == false)
            //{
                if (ClickAction.ToolMode == 1)
                {
                    //Create Asset

                }
                else if (ClickAction.ToolMode == 2)
                {
                    //Change Tile Type
                }
                else if (ClickAction.ToolMode == 3)
                {
                    //Create Pipe Mode
                }
                else if (ClickAction.ToolMode == 0)
                {
                    //Info mode


                    PanelTitleText = this.gameObject.name.ToString();
                    PanelTitleText = "Node " + PanelTitleText;
                    PanelManager.TitleText.text = PanelTitleText;
                    //PanelManager.TitleText.rectTransform.rect.yMax = 90;    

                    //ClickAction.PanelToggle = true;

                    //Debug.Log(this.gameObject.name + "      " + Height);
                }
                else
                {
                    Debug.Log("Tool Mode not configured correctly.");
                }
            //}
            //else

            //{
            //    UserInMenu = false;
            //    Debug.Log("Exiting Menu     " + UserInMenu);
            //}
        }
        //else
        //{

        //    UserInMenu = true;
        //    Debug.Log("Clicked Menu Bar   " + UserInMenu);
        //}
    }
}
