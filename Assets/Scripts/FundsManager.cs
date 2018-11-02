using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FundsManager : MonoBehaviour {

    Text text;
    public static string FundsText;


    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        text.text = FundsText;
	}
}
