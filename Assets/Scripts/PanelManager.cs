using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    public static Text TitleText;
    public static string CurrentItem;

    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    public Text Button1Text;
    public Text Button2Text;
    public Text Button3Text;
    public Text Button4Text;

    public string TileSearch;
    public string TileSearchLock;
    public GameObject CurrentTile;
    public bool CurrentTileWater;

    // Use this for initialization
    void Start () {

        TitleText = GameObject.Find("TitleText").GetComponent<UnityEngine.UI.Text>();
        Text1 = GameObject.Find("Text1").GetComponent<UnityEngine.UI.Text>();
        Text2 = GameObject.Find("Text2").GetComponent<UnityEngine.UI.Text>();
        Text3 = GameObject.Find("Text3").GetComponent<UnityEngine.UI.Text>();
        Text4 = GameObject.Find("Text4").GetComponent<UnityEngine.UI.Text>();
        Button1 = GameObject.Find("Button1").GetComponent<UnityEngine.UI.Button>();
        Button2 = GameObject.Find("Button2").GetComponent<UnityEngine.UI.Button>();
        Button3 = GameObject.Find("Button3").GetComponent<UnityEngine.UI.Button>();
        Button4 = GameObject.Find("Button4").GetComponent<UnityEngine.UI.Button>();
        Button1Text = GameObject.Find("Button1Text").GetComponent<UnityEngine.UI.Text>();
        Button2Text = GameObject.Find("Button2Text").GetComponent<UnityEngine.UI.Text>();
        Button3Text = GameObject.Find("Button3Text").GetComponent<UnityEngine.UI.Text>();
        Button4Text = GameObject.Find("Button4Text").GetComponent<UnityEngine.UI.Text>();
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
        if (CurrentItem == "HQ")
        {
            Text1.text = CurrentItem;
            Text2.text = "HQ3";
            Text3.text = "HQ2";
            Text4.text = "HQ1";

            Button1Text.text = "HQ1";
            Button2Text.text = "HQ2";
            Button3Text.text = "HQ3";
            Button4Text.text = "HQ4";
        }
        else if (CurrentItem == "Tile")
        {
            TileSearch = TitleText.text.ToString();
            TileSearch = TileSearch.Remove(0, 8);
            TileSearch = "T " + TileSearch;

            if (TileSearchLock == TileSearch)
            {

            }
            else
            {
                CurrentTile = GameObject.Find(TileSearch);
                CurrentTileWater = GameObject.Find(TileSearch).GetComponent<TileManager>().IsWater;
                TileSearchLock = TileSearch;

            }



            Text1.text = CurrentItem;
            Text2.text = TileSearch;
            Text3.text = CurrentTileWater.ToString();
            Text4.text = CurrentTile.GetComponent<TileManager>().DistanceToPipe.ToString();

            Button1Text.text = "Tile1";
            Button2Text.text = "Tile2";
            Button3Text.text = "Tile3";
            Button4Text.text = "Tile4";
        }
	}

    void OnMouseDown()
    {
        Debug.Log("Panel Clicked");
    }

}
