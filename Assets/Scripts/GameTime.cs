using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {

        float GameTime = Time.timeSinceLevelLoad;
        //GameTime.ToString("F2");

        //text.text = "Game time: " + GameTime.ToString("F0");
        text.text =  GameTime.ToString("F0");
    }
}
