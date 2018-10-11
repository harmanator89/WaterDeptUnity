using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveController : MonoBehaviour {

    public bool ValveStatus;
    public Material[] ValveMaterials;

    private GameObject UpstreamPart;
    private GameObject DownstreamPart;
    private Transform meeple;

    MeshRenderer m_Renderer;

    // Use this for initialization
    void Start () {
        meeple = this.gameObject.transform.GetChild(0);
        UpstreamPart = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        DownstreamPart = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (ValveStatus == true)
        {
            //Valve open
            m_Renderer = UpstreamPart.GetComponent<MeshRenderer>();
            m_Renderer.material = ValveMaterials[0];
        }
        else
        {
            //Valve closed
            //Child = GameObject.Find("Cone").GetComponentsInChildren;
            //Child = this.GetComponentInChildren;
            m_Renderer = UpstreamPart.GetComponent<MeshRenderer>();
            m_Renderer.material = ValveMaterials[1];
        }

	}

    void OnMouseDown()
    {
        ValveStatus = !ValveStatus;
    }
}
