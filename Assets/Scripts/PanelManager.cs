using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    public static Text TitleText;


	// Use this for initialization
	void Start () {

        TitleText = GameObject.Find("TitleText").GetComponent<UnityEngine.UI.Text>();

    }

    // Update is called once per frame
    void Update() {
        
        //Debug.Log(ClickAction.PanelToggle);

        //if (ClickAction.PanelToggle == true)
        //{
        //    this.gameObject.SetActive(true);
        //}
        //else
        //{
        //    this.gameObject.SetActive(false);
        //}

	}

}
