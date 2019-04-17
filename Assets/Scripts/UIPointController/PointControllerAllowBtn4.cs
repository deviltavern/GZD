using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn4 : PointControllerAllowBtn
{
    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J4;
        code = KeyCode.Alpha4;


    }
}
