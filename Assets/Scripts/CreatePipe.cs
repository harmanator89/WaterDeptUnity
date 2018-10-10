using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour{

    bool creating;
    public GameObject start;
    public GameObject end;

    private string StartName;
    private string StopName;

    public GameObject PipePreFab;
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
            SetStart();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            SetEnd();
        }
        else
        {
            if (creating)
            {
                Adjust();
            }
        }
    }

    void SetStart()
    {
        creating = true;
        start.transform.position = GetWorldPoint();
        StartName = start.transform.position.ToString();
        Pipe = Instantiate(PipePreFab, start.transform.position, Quaternion.identity) as GameObject;
        Pipe.transform.parent = GameObject.Find("PipeNetwork").transform;
        Pipe.transform.Rotate(90, 0, 0);
        
    }

    void SetEnd()
    {
        creating = false;
        end.transform.position = GetWorldPoint();
        StopName = end.transform.position.ToString();

        Pipe.name = "Pipe " + StartName + " to " + StopName;

        Debug.Log(Pipe.name + "  " + StartName + "   " + StopName);

    }

    void Adjust()
    {
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
        Pipe.transform.localScale = new Vector3(Pipe.transform.localScale.x, Pipe.transform.localScale.y, distance/2);

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
