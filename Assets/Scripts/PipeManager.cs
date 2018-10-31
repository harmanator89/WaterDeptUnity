using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour {

    public bool IsPlaced = false;

	// Use this for initialization
	void Start () {
        //Debug.Log("IMMA PIPE: " + this.name);
	}
	
	// Update is called once per frame
	void Update () {

        if (ClickAction.UpdateNetwork == true)
        {
            //Check Nodes
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
}
