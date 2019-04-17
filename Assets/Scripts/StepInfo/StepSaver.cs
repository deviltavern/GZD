using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSaver : StepInfoEvent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onClickBtn()
    {
        StepInfoCatcher.Instance.save();
    }
}
