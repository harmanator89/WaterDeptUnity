using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQManager : MonoBehaviour {

    private ClickAction ClickAction;
    private string PanelTitleText;

    // Use this for initialization
    void Start () {
		//somethign

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        if (ClickAction.ToolMode == 0)
        {
            PanelTitleText = "Your Headquarters";
            //PanelTitleText = PanelTitleText;
            PanelManager.TitleText.text = PanelTitleText;
            PanelManager.CurrentItem = "HQ";
        }
    }
}
