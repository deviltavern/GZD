using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SelectButtonItem : MonoBehaviour {
    Button button;
    public static Vector3 cameraPos { get; set; }

    public void Awake()
    {

        button = this.transform.GetComponent<Button>();

        button.onClick.AddListener(onClickThisButton);




    }

     public void Start()
    {
        cameraPos = MainCameraManager.mainCamera.transform.position;
    
    }
    public void Update() {
        if (Vector3.Distance(MainCameraManager.mainCamera.transform.position, cameraPos) > 3f)
        {
            Vector3 dir = Vector3.Normalize(cameraPos - MainCameraManager.mainCamera.transform.position);
            MainCameraManager.mainCamera.transform.position += dir * Time.deltaTime*90;
        
        }
    }
    public abstract void onClickThisButton();
	
}
