using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoint_3Controller : UIPointController {

    public override void Awake()
    {
        base.Awake();
        UIPointController.PointControllerDic.Add(AxleName.J3, this);
        PointControllerID = AxleName.J3;
        swingleft.gameObject.SetActive(false);
        swingright.gameObject.SetActive(false);
        swingbar.gameObject.SetActive(false);


    }



    public override void Update()
    {
        base.Update();
        point.transform.localRotation = Quaternion.Euler(new Vector3(savePreVector3.x, savePreVector3.y, savePreVector3.z + 360 * (nodbar.value - 0.5f)));
    }

    public override void Start()
    {


        point = RobotA.Instance.axleDic[AxleName.J3];
        StepController.pointDic.Add(3, this.point);

    }
}
