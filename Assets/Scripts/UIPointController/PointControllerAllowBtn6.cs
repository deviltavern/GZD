using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn6 : PointControllerAllowBtn
{
    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J6;
        code = KeyCode.Alpha6;


    }
}
