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
        cameraFocus.transform.SetParent(info.aimObje.transform);
        cameraFocus.transform.localPosition = new Vector3();
        cameraFocus.transform.SetParent(null);

        aimItem = info.aimObje.gameObject;

        lastObject = aimItem;
     
        allowCameraRotation = true;
        
    }

}
