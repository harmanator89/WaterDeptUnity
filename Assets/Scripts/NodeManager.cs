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
}
