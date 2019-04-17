using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoverArea : ButtonEventBase {



    public GameObject areaItem;


    void Start()
    {
        areaItem = GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem]);

        areaItem.SetActive(false);


    
    }



    int index = 0;
    Ray ray;
    RaycastHit hit;
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isTouch = Physics.Raycast(ray, out hit);

        if (isTouch == true)
        {

            areaItem.transform.position = new Vector3(hit.point.x,0,hit.point.z);
            if (Input.GetMouseButtonDown(0) && index % 2 == 1)
            {
                areaItem.SetActive(false);
                ShapeItemRecoverByListInfo.Recover(hit.point, ShapeItemCatcher.getData(), new Color(	255/255, 127/255, 0,1));
                index++;
            }
        }

       
       // Vector3 pos = Camera.main.ViewportToWorldPoint();
        //Debug.Log(Input.mousePosition);
       // areaItem.transform.position =new Vector3(pos.x,0,pos.z);
    }
    public override void onClickButton()
    {
        if (index % 2 == 0)
        {
            areaItem.SetActive(true);
            index++;
        }
        else
        {
            areaItem.SetActive(false);
        }
       
    }
}
