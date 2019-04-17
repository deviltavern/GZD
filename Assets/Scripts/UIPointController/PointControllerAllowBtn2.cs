using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn2 : PointControllerAllowBtn
{


    

    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J2;

        code = KeyCode.Alpha2;
    }


   
}
