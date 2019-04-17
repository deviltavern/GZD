using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn5 : PointControllerAllowBtn
{
    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J5;

        code = KeyCode.Alpha5;

    }
}
