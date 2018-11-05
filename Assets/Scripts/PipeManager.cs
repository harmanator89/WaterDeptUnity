using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour {

    public bool IsPlaced = false;
    public float Length;
    private string PanelTitleText;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (ClickAction.UpdateNetwork == true)
        {
            //Check Nodes
            //Debug.Log("Updating " + this.name);
            ClickAction.PipeUpdatedCount += 1;
        }

        if (IsPlaced == true)
        {
            //Debug.Log("IMMA PIPE: " + this.name);
        }
        else
        {

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
                PanelTitleText = "Pipe " + PanelTitleText;
                PanelManager.TitleText.text = PanelTitleText;
                //PanelManager.TitleText.rectTransform.rect.yMax = 90;    

                //ClickAction.PanelToggle = true;

                //Debug.Log(this.gameObject.name + "      " + Height);
            }
            else
            {
                Debug.Log("Tool Mode not configured correctly.");
            }
        }
    }
}
