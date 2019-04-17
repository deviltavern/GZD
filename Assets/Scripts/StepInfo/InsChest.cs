using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsChest : StepInfoEvent {

	
    public override void onClickBtn()
    {

        GameObject insChest = GameObject.Instantiate(ResourcesManager.prefabDic["chest"]);

        insChest.transform.position = StepController.preChestDefaultVec;
        StepController.preChest = insChest;


        StepInfo info = new StepInfo();
        StepInfoCatcher.Instance.addStep(info, StepType.insChest);

    }
}
