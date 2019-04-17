using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoint_6Controller : UIPointController {

    public override void Awake()
    {
        base.Awake();
        UIPointController.PointControllerDic.Add(AxleName.J6, this);

        PointControllerID = AxleName.J6;
        

    }
    public override void Update()
    {
        base.Update();
        point.transform.localRotation = Quaternion.Euler(new Vector3(savePreVector3.x + 360 * (swingbar.value - 0.5f), savePreVector3.y, savePreVector3.z));
    }



    public override void Start()
    {
        point = RobotA.Instance.axleDic[AxleName.J6];
        StepController.pointDic.Add(6, this.point);

    }
}
