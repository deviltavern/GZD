using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoint_5Controller : UIPointController {

    public override void Awake()
    {
        base.Awake();
        UIPointController.PointControllerDic.Add(AxleName.J5, this);

        PointControllerID = AxleName.J5;


    }



    public override void Update()
    {
        base.Update();
        point.transform.localRotation = Quaternion.Euler(new Vector3(savePreVector3.x, savePreVector3.y, savePreVector3.z + 360 * (nodbar.value - 0.5f)));
    }

    public override void Start()
    {
        point = RobotA.Instance.axleDic[AxleName.J5];
        StepController.pointDic.Add(5, this.point);

    }
}
