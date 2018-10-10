using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour{

    bool creating;
    private GameObject start;
    private GameObject end;

    private string StartName;
    private string StopName;

    private Vector3 StartVector;
    private Vector3 StopVector;
    private Vector3 ObjectHit;
    private string ObjectHitName;
    private string ObjectHitParentName;

    private bool DestroyStart;
    private bool DestroyStop;

    public GameObject PipePreFab;
    public GameObject NodePreFab;
    GameObject Pipe;
    public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    void GetInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (ClickAction.ToolMode == 3)
            {
                SetPipeStart();
            }
            else if (ClickAction.ToolMode == 1)
            {

            }

        }
        else if (Input.GetMouseButtonUp(1))
        {
            if (ClickAction.ToolMode == 3)
            {
                SetPipeEnd();

            }
        }
        else
        {
            if (creating)
            {
                if (ClickAction.ToolMode == 3)
                {
                    Adjust();
                }
              
            }
        }
    }

    void SetPipeStart()
    {
        creating = true;
        RaycastHit hitInfo;
        string TestString;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitInfo);
        ObjectHit = hitInfo.transform.gameObject.transform.position;

        ObjectHitParentName = hitInfo.transform.parent.name;
        ObjectHitName = hitInfo.transform.name;

        Debug.Log("Parent: " + ObjectHitParentName);
        Debug.Log("Name: " + ObjectHitName);

        if (ObjectHitParentName == "PipeNetwork" || ObjectHitParentName == "AssetRegistry")
        {
            //start = Instantiate(NodePreFab);
            start = GameObject.Find(hitInfo.transform.name);
            DestroyStart = true;
            //Debug.Log("start instantiate complete.");

            start.transform.position = ObjectHit;
            //Need to not instantiate if node already exists.......

            //Debug.Log("start transform complete");

            start.name = "Node @ " + start.transform.position.ToString();
            start.transform.parent = GameObject.Find("PipeNetwork").transform;
            start.layer = 0;
            StartName = start.transform.position.ToString();

            end = Instantiate(NodePreFab);

            end.transform.position = GetWorldPoint();

            //end.name = "Node @ " + end.transform.position.ToString();
            end.transform.parent = GameObject.Find("PipeNetwork").transform;


            Pipe = Instantiate(PipePreFab, start.transform.position, Quaternion.identity) as GameObject;
            Pipe.transform.parent = GameObject.Find("PipeNetwork").transform;
            //Pipe.transform.Rotate(90, 0, 0);
        }
        else
        {
            start = Instantiate(NodePreFab);
            DestroyStart = false;

            //Debug.Log("start instantiate complete.");

            start.transform.position = ObjectHit;
            //Need to not instantiate if node already exists.......

            //Debug.Log("start transform complete");

            start.name = "Node @ " + start.transform.position.ToString();
            start.transform.parent = GameObject.Find("PipeNetwork").transform;
            start.layer = 0;
            StartName = start.transform.position.ToString();

            end = Instantiate(NodePreFab);

            end.transform.position = GetWorldPoint();

            //end.name = "Node @ " + end.transform.position.ToString();
            end.transform.parent = GameObject.Find("PipeNetwork").transform;


            Pipe = Instantiate(PipePreFab, start.transform.position, Quaternion.identity) as GameObject;
            Pipe.transform.parent = GameObject.Find("PipeNetwork").transform;
            //Pipe.transform.Rotate(90, 0, 0);
        }
    }

    void SetPipeEnd()
    {
        creating = false;
        //Debug.Log("Setting Pipe End " + DestroyStop);

        if (DestroyStop == false)
        {
            end.name = "Node @ " + end.transform.position.ToString();
            end.layer = 0;
            StopName = end.transform.position.ToString();
            //end.transform.position =

            Pipe.name = "Pipe " + StartName + " to " + StopName;

            //Debug.Log(Pipe.name + "  " + StartName + "   " + StopName);
        }
        else
        {
            StopName = end.transform.position.ToString();
            Pipe.name = "Pipe " + StartName + " to " + StopName;
            GameObject.Destroy(end);
        }


    }

    void Adjust()
    {
        RaycastHit hitInfo;
        string TestString;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitInfo);
        ObjectHit = hitInfo.transform.gameObject.transform.position;

        ObjectHitParentName = hitInfo.transform.parent.name;
        ObjectHitName = hitInfo.transform.name;

        //Debug.Log("Parent: " + ObjectHitParentName);
        //Debug.Log("Name: " + ObjectHitName);

        if (ObjectHitParentName == "PipeNetwork" || ObjectHitParentName == "AssetRegistry")
        {
            DestroyStop = true;
        }
        else
        {
            DestroyStop = false;
        }

        end.transform.position = ObjectHit;
        //Debug.Log(DestroyStop);
        //end.transform.position = GetWorldPoint();
        AdjustPipe();
    }

    void AdjustPipe()
    {
        start.transform.LookAt(end.transform);
        end.transform.LookAt(start.transform);

        float distance = Vector3.Distance(start.transform.position, end.transform.position);

        Pipe.transform.position = start.transform.position + distance / 2 * start.transform.forward;

        Pipe.transform.rotation = start.transform.rotation;
        Pipe.transform.localScale = new Vector3(Pipe.transform.localScale.x, 0.5f, distance/2);

    }

    Vector3 GetWorldPoint()
    {
        RaycastHit hitInfo;
        string TestString;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 objectHit = hitInfo.transform.gameObject.transform.position;
            TestString = hitInfo.transform.parent.name;
            
            //Debug.Log(message: hitInfo.transform.parent.name);
            return objectHit;

        }
        return Vector3.zero;
    }
    void OnMouseDown()
    {

        Debug.Log("CreatePipe On mouse down");

    }

    //void StartPipe(Vector3 initialPosition)
    //{
    //    Debug.Log(initialPosition);
    //}
}
