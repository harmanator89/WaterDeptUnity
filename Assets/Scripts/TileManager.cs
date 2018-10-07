using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {


    private ClickAction clickAction;
    bool status = true;
    public Material[] tileMaterials;

    public int currentMaterial;
    public int newMaterial;
    public bool TileSelected;

    private bool UserInMenu = false;

    public static Material CurrentType;


    MeshRenderer m_Renderer;





    // Use this for initialization
    void Start() {
        m_Renderer = GetComponent<MeshRenderer>();
        m_Renderer.material = tileMaterials[0];
    }

    // Update is called once per frame
    void Update() {
        if (currentMaterial == 0)
        {
            m_Renderer.material = tileMaterials[0];
        }
        else if (currentMaterial == 1)
        {
            m_Renderer.material = tileMaterials[1];
        }
        else if (currentMaterial == 2)
        {
            m_Renderer.material = tileMaterials[2];
        }
        else if (currentMaterial == 3)
        {
            m_Renderer.material = tileMaterials[3];
        }
        else if (currentMaterial == 4)
        {
            m_Renderer.material = tileMaterials[4];
        }
        else if (currentMaterial == 5)
        {
            m_Renderer.material = tileMaterials[5];
        }
        else if (currentMaterial == 6)
        {
            m_Renderer.material = tileMaterials[6];
        }
        else if (currentMaterial == 7)
        {
            m_Renderer.material = tileMaterials[7];
        }
        else if (currentMaterial == 8)
        {
            m_Renderer.material = tileMaterials[8];
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
                }
                else
                {
                    //Info mode
                    //Debug.Log(this.gameObject.name);
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

    public void ChangeType(int newType, int oldType)
    {

    }


}
