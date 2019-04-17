using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonItem_pattern1 : SelectButtonItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void onClickThisButton()
    {
        cameraPos = new Vector3(0, 7, 0);
                                  
    }
}
