using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn3 : PointControllerAllowBtn {

    
    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J3;
        code = KeyCode.Alpha3;
    }


   
}
