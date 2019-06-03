using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Camera : Strategy {


    private bool viewStatu;

    public GameObject viewItem;
    Texture2D cameraViewTexture;
    int openOrOff = 0;


    public Vector3 cameraInitPosition;

    public Quaternion cameraInitRotation;


    public Vector3 PrePosition;
    public Quaternion PreRotation;

    public StrategyMaster master;

    public InputStrategy_Camera(StrategyMaster _master)
    {

        cameraViewTexture = Resources.Load<Texture2D>("cameraViewStatus");
        cameraInitPosition = MainCameraManager.mainCamera.transform.position;
        cameraInitRotation = MainCameraManager.mainCamera.transform.rotation;

        master =_master;
    }

    public override void doSomthing()
    {

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                master.endStrategy();
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                viewStatu = false;

                MainCameraManager.mainCamera.transform.SetParent(null);
                MainCameraManager.mainCamera.transform.position = cameraInitPosition;

                MainCameraManager.mainCamera.transform.rotation = cameraInitRotation;
                openOrOff = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                master.endStrategy();
                if (openOrOff % 2 == 0)
                {
                    Cursor.SetCursor(cameraViewTexture, Vector2.zero, CursorMode.Auto);
                    MainCameraManager.mainCamera.transform.SetParent(null);
                    MainCameraManager.mainCamera.transform.position = cameraInitPosition;

                    MainCameraManager.mainCamera.transform.rotation = cameraInitRotation;
                    viewStatu = true;

                }
                else

                {

                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    viewStatu = false;

                    MainCameraManager.mainCamera.transform.SetParent(null);

                }
                openOrOff++;

            }
        }
       


        if (viewStatu == true)
        {

            LayerStructure3DManager.Instance.viewItem.transform.localRotation = 
                Quaternion.Euler(LayerStructure3DManager.Instance.viewItem.transform.localEulerAngles + new Vector3(0, Input.mouseScrollDelta.y, 0));

            MainCameraManager.mainCamera.transform.SetParent(LayerStructure3DManager.Instance.viewItemSon.transform);

            MainCameraManager.mainCamera.transform.localPosition = new Vector3();
        
            MainCameraManager.mainCamera.transform.SetParent(null);
            MainCameraManager.mainCamera.transform.LookAt(LayerStructure3DManager.Instance.viewItem.transform.position);

        }

    }

    public override void onEnd()
    {
        
    }

    public override void waitting()
    {
        
    }

}
