using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControllerAllowBtn1 : PointControllerAllowBtn {


   


    public override void Awake()
    {
        base.Awake();
        controllerID = AxleName.J1;
        StartCoroutine(IEDelayStart());
        code = KeyCode.Alpha1;


    }

    public void Start()
    {
        
    }


    IEnumerator IEDelayStart()
    {
        yield return new WaitForSeconds(Time.deltaTime * 3);
        onClickThisButton();
    }
}
