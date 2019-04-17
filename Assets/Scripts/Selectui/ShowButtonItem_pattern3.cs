using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonItem_pattern3 : SelectButtonItem {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

     
    public override void onClickThisButton()
    {
        cameraPos = new Vector3(0, 7, -100);
    }
}
