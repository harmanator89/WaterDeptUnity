using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolModeManager : MonoBehaviour {

    public Button ThisButton;

    // Use this for initialization
    void Start () {
        ThisButton = GameObject.Find("CreateAssetButton").GetComponent<Button>();

    }
	
	// Update is called once per frame
	void Update () {
        Dropdown CurrentToolMode = GameObject.Find("ToolMode").GetComponent<Dropdown>();
        string CurrentToolString = CurrentToolMode.captionText.text;

        //if (CurrentToolString == "Create Asset")
        //{
        //    ThisButton.gameObject.SetActive(true);
        //}
        //else
        //{
        //    ThisButton.gameObject.SetActive(false);
        //}
    }
}

