using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour{

    bool creating;
    private GameObject start;
    private GameObject end;

    private string StartName;
    private string StopName;

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
        start = Instantiate(NodePreFab);

        Debug.Log("instantiate complete.");

        start.transform.position = GetWorldPoint();
        //Need to not instantiate if node already exists.......

        Debug.Log("transform compelte");

        start.name = "Node @ " + start.transform.position.ToString();
        start.transform.parent = GameObject.Find("PipeNetwork").transform;
        StartName = start.transform.position.ToString();



        end = Instantiate(NodePreFab);

        end.transform.position = GetWorldPoint();
        

        //end.name = "Node @ " + end.transform.position.ToString();
        end.transform.parent = GameObject.Find("PipeNetwork").transform;




        Pipe = Instantiate(PipePreFab, start.transform.position, Quaternion.identity) as GameObject;
        Pipe.transform.parent = GameObject.Find("PipeNetwork").transform;
        //Pipe.transform.Rotate(90, 0, 0);
        
    }

    void SetPipeEnd()
    {
        creating = false;

        end.name = "Node @ " + end.transform.position.ToString();
        StopName = end.transform.position.ToString();
        //end.transform.position =

        Pipe.name = "Pipe " + StartName + " to " + StopName;

        Debug.Log(Pipe.name + "  " + StartName + "   " + StopName);

    }

    void Adjust()
    {
        //end = Instantiate(NodePreFab);
        end.transform.position = GetWorldPoint();
        AdjustPipe();
    }

    void AdjustPipe()
    {
        start.transform.LookAt(end.transform);
        end.transform.LookAt(start.transform);

        float distance = Vector3.Distance(start.transform.position, end.transform.position);
        //Quaternion PipeRotate;
        //PipeRotate.x = 90;
        //PipeRotate.y = start.transform.rotation.y;
        //PipeRotate.z = start.transform.rotation.z;
        //PipeRotate.w = 0;
        Pipe.transform.position = start.transform.position + distance / 2 * start.transform.forward;
        //Pipe.transform.rotation = PipeRotate;
        Pipe.transform.rotation = start.transform.rotation;
        Pipe.transform.localScale = new Vector3(Pipe.transform.localScale.x, 0.5f, distance/2);
        //Pipe.transform.localScale.y
    }

    Vector3 GetWorldPoint()
    {
        RaycastHit hitInfo;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 objectHit = hitInfo.transform.gameObject.transform.position;
            //Debug.Log(objectHit);
            return objectHit;

        }
        return Vector3.zero;
    }
    void OnMouseDown()
    {

        Debug.Log("CreatePipe On mouse down");

    }

    void StartPipe(Vector3 initialPosition)
    {
        Debug.Log(initialPosition);
    }
}
