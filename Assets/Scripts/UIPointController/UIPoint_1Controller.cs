using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoint_1Controller : UIPointController {

    public override void Awake()
    {
        base.Awake();

        PointControllerID = AxleName.J1;
        UIPointController.PointControllerDic.Add(AxleName.J1, this);

        nodbar.gameObject.SetActive(false);

        swingleft.gameObject.SetActive(false);
        swingright.gameObject.SetActive(false);
        swingbar.gameObject.SetActive(false);

        
    }

    public override void Update()
    {
        Debug.Log("我是xxx");
        base.Update();
        point.transform.localRotation = Quaternion.Euler(new Vector3(savePreVector3.x, savePreVector3.y + 360 * (turnbar.value - 0.5f),savePreVector3.z));
        axleValue.text = point.transform.localRotation.y * 180 + "";
    }

  

    public override void Start()
    {
        point = RobotA.Instance.axleDic[AxleName.J1];
        StepController.pointDic.Add(1,this.point);
       
    }

    
}
