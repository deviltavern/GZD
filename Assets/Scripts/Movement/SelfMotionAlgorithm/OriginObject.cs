using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginObject : MonoBehaviour {

    public static GameObject originObj;
	void Awake () {

        originObj = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
