using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour ,IViewer {


    public GameObject cameraFocus;
    public GameObject cameraPoint;
    public static CameraRotation Instance;


    public GameObject aimItem;
    public bool allowCameraRotation = false;

    public Vector3 initEuler;
    public Vector3 initPosition;

    public Color color = new Color(238/255f ,0 ,238/255f,1);

    public Color lastColor;
    public GameObject lastObject;

    void Awake()
    {
        Instance = this;
        allowCameraRotation = false;

        cameraFocus = GameObject.Find("CameraFocus");
        cameraPoint = cameraFocus.transform.Find("CameraPoint").gameObject ;

       
    }
    void Start()
    {
        initEuler = MainCameraManager.mainCamera.transform.eulerAngles;
        initPosition = MainCameraManager.mainCamera.transform.position;
    
    }
    int index = 0;


    Ray ray;
    RaycastHit hit;


    void Update()
    {



     // if (Input.GetKeyDown(KeyCode.R))
     // {
     //
     //    
     //
     //     
     //     if (index % 2 == 0)
     //     {
     //
     //         allowCameraRotation = true;
     //     }
     //     else
     //     {
     //
     //         allowCameraRotation = false;
     //         MainCameraManager.mainCamera.transform.position = initPosition;
     //         MainCameraManager.mainCamera.transform.eulerAngles = initEuler;
     //     }
     //     index++;
     // 
     //     
     // }

        if (allowCameraRotation == true)
        {


            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                bool isHit = Physics.Raycast(ray, out hit);
                Debug.Log("选中物体！");
                if (isHit == true)
                {

                    if (lastObject != null)
                    {
                        lastObject.GetComponent<MeshRenderer>().material.color = lastColor;
                        

                    }
                    Debug.Log("选中物体！");
                    cameraFocus.transform.SetParent(hit.collider.transform);
                    cameraFocus.transform.localPosition = new Vector3();
                    cameraFocus.transform.SetParent(null);

                    aimItem = hit.collider.gameObject;

                    lastObject = aimItem;
                    lastColor = aimItem.GetComponent<MeshRenderer>().material.color;

                       
                    aimItem.GetComponent<MeshRenderer>().material.color = color;


                  
                    
                }
            }
            cameraFocus.transform.eulerAngles += new Vector3(0,Input.mouseScrollDelta.y*10,0);
            cameraPoint.transform.SetParent(null);
            cameraPoint.transform.SetParent(cameraFocus.transform);

            if (aimItem != null)
            {
                MainCameraManager.mainCamera.transform.position = cameraPoint.transform.position;

                MainCameraManager.mainCamera.transform.LookAt(aimItem.transform.position);
            }
           


        }
        else
        { 
        
            
        }
        Debug.Log(Input.mouseScrollDelta);
    }

    public void update(ViewInfo info)
    {
        throw new System.NotImplementedException();
    }

    public void addViewer(IViewer view)
    {
        throw new System.NotImplementedException();
    }

    public void deleteViewer(IViewer view)
    {
        throw new System.NotImplementedException();
    }

    public void broadCast(ViewInfo info)
    {
        throw new System.NotImplementedException();
    }
}
