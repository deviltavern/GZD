using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInsChestBtn : StepInfoEvent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onClickBtn()
    {


        Destroy(StepController.preChest);
        Robots.Instance.Box.SetActive(true);
        StepInfo info = new StepInfo();
        info.type = (int)StepType.insChest ;
        StepInfoCatcher.Instance.addStep(info, StepType.catchChest);



      
    }
}
