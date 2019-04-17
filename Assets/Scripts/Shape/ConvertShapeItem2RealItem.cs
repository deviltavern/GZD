using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertShapeItem2RealItem : ButtonEventBase {

	// Use this for initialization
	void Start () {
        tex = Resources.Load<Texture2D>(ResName.hammer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    Texture2D tex;
    
    public override void onClickButton()
    {
        Debug.Log(tex);
        Debug.Log("点击了？？");
        Cursor.SetCursor(tex,new Vector2(),CursorMode.Auto);



    }
}
