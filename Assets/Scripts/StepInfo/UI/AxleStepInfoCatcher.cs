using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleStepInfoCatcher : ButtonEventBase {

	
    public override void onClickButton()
    {

        AxleStepInfoRecord.save2AxleStepInfoList(new AxleStepInfo(RobotA.Instance.getAxleDataList()));



    }
}
