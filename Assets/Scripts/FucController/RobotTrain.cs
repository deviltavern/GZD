using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrain : ButtonEventBase {


    void Start()
    {
       
        
    }


    public override void onClickButton()
    {
        RobotA.reTrain();
        PlayerPrefs.SetString("animation", "");
        UIMaster.pointController.gameObject.SetActive(true);
        StepInfoDispose.Instance.gameObject.SetActive(false);

    }
}
