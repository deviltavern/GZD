using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchReleaseChestBtn : StepInfoEvent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public override void onClickBtn()
    {
        Robots.Instance.Box.SetActive(false);
        GameObject insBox = GameObject.Instantiate(Robots.Instance.Box, Robots.Instance.Box.transform);
        insBox.transform.localPosition = new Vector3();
        insBox.transform.SetParent(null);
        Rigidbody rig = insBox.AddComponent<Rigidbody>();
        rig.drag = 10;
        rig.mass = 100;
        insBox.SetActive(true);
        StepInfo info = new StepInfo();
        info.type = (int)StepType.releaseChest;


       // StepInfoCatcher.stepInfoList.Add(info.toJson());

        StepInfoCatcher.Instance.addStep(info, StepType.releaseChest);



    }
}
