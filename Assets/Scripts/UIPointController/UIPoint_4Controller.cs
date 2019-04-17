using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPoint_4Controller : UIPointController {

    public override void Awake()
    {
        base.Awake();
        UIPointController.PointControllerDic.Add(AxleName.J4, this);
        PointControllerID = AxleName.J4;
      //  swingleft.gameObject.SetActive(false);
      //  swingright.gameObject.SetActive(false);
      //  swingbar.gameObject.SetActive(false);


    }




    public override void Update()
    {
        base.Update();
        point.transform.localRotation = Quaternion.Euler(new Vector3(savePreVector3.x + 360 * (swingbar.value - 0.5f), savePreVector3.y, savePreVector3.z));
    }
    public override void Start()
    {
        point = RobotA.Instance.axleDic[AxleName.J4];
        StepController.pointDic.Add(4, this.point);

    }
}
