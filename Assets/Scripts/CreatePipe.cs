using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePipe : MonoBehaviour{

    bool creating;
    private GameObject start;
    private GameObject end;

    private GameObject PlayerBase;
    private float PlayerBaseX;
    private float PlayerBaseY;

    private string StartName;
    private string StopName;

    private Vector3 StartVector;
    private Vector3 StopVector;
    private float Distance;
    private Vector3 ObjectHit;
    private string ObjectHitName;
    private string ObjectHitParentName;

    private bool DestroyStart;
    private bool DestroyStop;

    public GameObject PipePreFab;
    public GameObject NodePreFab;
    public GameObject[] Assets;
    GameObject Pipe;
    public Camera camera;

	// Use this for initialization
	void Start () {
        PlayerBase = Instantiate(Assets[4]);
        PlayerBaseX = HexTileMapGenerator.mapWidth / 2;
        PlayerBaseY = HexTileMapGenerator.mapHeight / 2;
        Vector3 PlayerBasePos = new Vector3(PlayerBaseX, 0.18f, PlayerBaseY);
        PlayerBase.gameObject.transform.position = PlayerBasePos;
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
                Debug.Log("Create Pipe / Asset Mode");

                RaycastHit hitInfo;

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hitInfo);
                ObjectHit = hitInfo.transform.gameObject.transform.position;

                ObjectHitParentName = hitInfo.transform.parent.name;
                ObjectHitName = hitInfo.transform.name;
                if (ObjectHitParentName == "PipeNetwork" || ObjectHitParentName == "AssetRegistry")
                {
                    //Error Msg: Object already here, cannot create new asset.
                }
                else
                {
                    if (ClickAction.AssetMode == 0)
                    {
                        //Tank
                        start = Instantiate(Assets[0]);

                        Debug.Log("tank instantiate complete.");

                        Vector3 m = new Vector3(ObjectHit.x, 0.355f, ObjectHit.z);
                        start.transform.position = m;

                        Debug.Log("tank transform complete");

                        start.name = "Tank @ " + start.transform.position.ToString();
                        start.transform.parent = GameObject.Find("AssetRegistry").transform;
                    }
                    else if (ClickAction.AssetMode == 1)
                    {
                        //Pump
                        start = Instantiate(Assets[1]);

                        Debug.Log("pump instantiate complete.");

                        Vector3 m = new Vector3(ObjectHit.x, 0.127f, ObjectHit.z);
                        start.transform.position = m;

                        Debug.Log("pump transform complete");

                        start.name = "Pump @ " + start.transform.position.ToString();
                        start.transform.parent = GameObject.Find("AssetRegistry").transform;
                    }
                    else if (ClickAction.AssetMode == 2)
                    {
                        //PRV
                        start = Instantiate(Assets[2]);

                        Debug.Log("PRV instantiate complete.");

                        Vector3 m = new Vector3(ObjectHit.x, 0.1f, ObjectHit.z);
                        start.transform.position = m;

                        Debug.Log("PRV transform complete");

                        start.name = "PRV @ " + start.transform.position.ToString();
                        start.transform.parent = GameObject.Find("AssetRegistry").transform;
                    }
                    else if (ClickAction.AssetMode == 3)
                    {
                        //Valve
                        start = Instantiate(Assets[3]);

                        Debug.Log("Valve instantiate complete.");

                        Vector3 m = new Vector3(ObjectHit.x, 0.1f, ObjectHit.z);
                        start.transform.position = m;

                        Debug.Log("Valve transform complete");

                        start.name = "Valve @ " + start.transform.position.ToString();
                        start.transform.parent = GameObject.Find("AssetRegistry").transform;
                    }
                    else if (ClickAction.AssetMode == 5)
                    {
                        //Water Treatment
                        start = Instantiate(Assets[5]);

                        Debug.Log("Water Treatment Instantiate complete.");

                        Vector3 m = new Vector3(ObjectHit.x - 1.541f, 0.1f, ObjectHit.z + .509f);
                        start.transform.position = m;

                        Debug.Log("WT transform complete");

                        start.name = "WaterTreatment @ " + start.transform.position.ToString();
                        start.transform.parent = GameObject.Find("AssetRegistry").transform;
                    }

                }
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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hitInfo);
        ObjectHit = hitInfo.transform.gameObject.transform.position;
        

        ObjectHitParentName = hitInfo.transform.parent.name;
        ObjectHitName = hitInfo.transform.name;

        //Debug.Log("Parent: " + ObjectHitParentName);
        //Debug.Log("Name: " + ObjectHitName);
        //Debug.Log("Name: " + ObjectHitName);

        if (ObjectHitParentName == "PipeNetwork" || ObjectHitParentName == "AssetRegistry")
        {
            //If game object is already present in PipeNetwork or AssetRegistry, use that instead of new.
            start = GameObject.Find(hitInfo.transform.name);
            DestroyStart = true;

            start.transform.position = ObjectHit;
            
            if (ObjectHitParentName == "PipeNetwork")
            {
                start.name = start.transform.position.x.ToString() + "," + start.transform.position.z.ToString();
                start.transform.parent = GameObject.Find("PipeNetwork").transform;
                start.layer = 0;
            }
            else
            {

            }
            start.layer = 0;
            StartName = start.transform.position.x.ToString() + "," + start.transform.position.z.ToString();

            end = Instantiate(NodePreFab);
            camera.GetComponent<ClickAction>().NodeCount += 1;

            end.transform.position = GetWorldPoint();
            end.transform.parent = GameObject.Find("PipeNetwork").transform;


            Pipe = Instantiate(PipePreFab, start.transform.position, Quaternion.identity) as GameObject;
            Pipe.transform.parent = GameObject.Find("PipeNetwork").transform;

        }
        else
        {
            start = Instantiate(NodePreFab);
            camera.GetComponent<ClickAction>().NodeCount += 1;
            DestroyStart = false;

            StartVector = new Vector3(ObjectHit.x, 0.9f, ObjectHit.z);

            start.transform.position = StartVector;

            start.name = start.transform.position.x.ToString() + "," + start.transform.position.z.ToString();
            start.transform.parent = GameObject.Find("PipeNetwork").transform;
            start.layer = 0;
            StartName = start.transform.position.x.ToString() + "," + start.transform.position.z.ToString();

            end = Instantiate(NodePreFab);
            camera.GetComponent<ClickAction>().NodeCount += 1;

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
        Debug.Log(Distance);
        if (DestroyStop == false)
        {
            end.name = end.transform.position.x.ToString() + "," + end.transform.position.z.ToString();
            end.layer = 0;
            StopName = end.transform.position.x.ToString() + "," + end.transform.position.z.ToString();


            Pipe.name = "Pipe(" + StartName + ":" + StopName + ")";
            Pipe.layer = 0;
            Pipe.GetComponent<PipeManager>().IsPlaced = true;
            Pipe.GetComponent<PipeManager>().Length = Distance;
            ClickAction.NodeUpdateCount = 0;
            ClickAction.PipeUpdatedCount = 0;

            //Debug.Log(Pipe.name + "  " + StartName + "   " + StopName);
        }
        else
        {
            StopName = end.transform.position.x.ToString() + "," + end.transform.position.z.ToString();
            Pipe.name = "Pipe(" + StartName + ":" + StopName + ")";
            Pipe.layer = 0;
            Pipe.GetComponent<PipeManager>().IsPlaced = true;
            GameObject.Destroy(end);
            camera.GetComponent<ClickAction>().NodeCount -= 1;
        }

        camera.GetComponent<ClickAction>().PipeCount += 1;
        Debug.Log("Pipe Count = " + camera.GetComponent<ClickAction>().PipeCount + " Node Count = " + camera.GetComponent<ClickAction>().NodeCount);
    }

    void Adjust()
    {
        RaycastHit hitInfo;
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

        StopVector = new Vector3(ObjectHit.x, 0.9f, ObjectHit.z);
        end.transform.position = StopVector;
        //Debug.Log(DestroyStop);
        //end.transform.position = GetWorldPoint();
        AdjustPipe();
    }

    void AdjustPipe()
    {
        start.transform.LookAt(end.transform);
        end.transform.LookAt(start.transform);

        Distance = Vector3.Distance(start.transform.position, end.transform.position);

        Pipe.transform.position = start.transform.position + Distance / 2 * start.transform.forward;

        Pipe.transform.rotation = start.transform.rotation;
        Pipe.transform.localScale = new Vector3(Pipe.transform.localScale.x, 0.5f, Distance/2);

    }

    Vector3 GetWorldPoint()
    {
        RaycastHit hitInfo;
        string TestString;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 objectHit = hitInfo.transform.gameObject.transform.position;
            objectHit = new Vector3(objectHit.x, 0.9f, objectHit.z);
            TestString = hitInfo.transform.parent.name;
            
            //Debug.Log(objectHit);
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
