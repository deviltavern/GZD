using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Edit : StrategyTemplatesEX,IViewer {

    

    
    public string pointType;
    public int pointDirction;
    public string editValue;
    public static InputStrategy_Edit instance;
    public static int value;


    public InputStrategy_Edit(StrategyMaster master)
        : base(master)
       
    {
       instance = this;

    }
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
         
        
       


	}

    public override void doSomthing()
    {

        
        if (Input.GetMouseButton(0))
            {

           
                if (LayerStructrueDataCache.Instance.pointBox != null)
                {
                    pointType = LayerStructrueDataCache.Instance.pointBox.tag;
                    pointDirction = InputStrategy_Stretch.faceType;
                  
                    EidtVaule.Instance.pointText.text = "选择类型：" + pointType + "--选择方向：" + pointDirction;
                    editValue = EidtVaule.Instance.EidtInput.text;
                 
                  
                }  

     

        }
    }

    public override void waitting()
    {

    }

    public override void onEnd()
    {

    }

    public void update(ViewInfo info)
    {

        value = int.Parse(info.arg1);

        switch (InputStrategy_Stretch.faceType)
        {

            case 0:
                LayerStructrueDataCache.Instance.pointBox.transform.localScale = new Vector3(float.Parse(EidtVaule.Instance.EidtInput.text), LayerStructrueDataCache.Instance.pointBox.transform.localScale.y, LayerStructrueDataCache.Instance.pointBox.transform.localScale.z);
                Debug.Log("点击的值" + value);
                break;
            case 1:
                LayerStructrueDataCache.Instance.pointBox.transform.localScale = new Vector3(LayerStructrueDataCache.Instance.pointBox.transform.localScale.x, float.Parse(EidtVaule.Instance.EidtInput.text), LayerStructrueDataCache.Instance.pointBox.transform.localScale.z);
                Debug.Log("点击的值" + value);
                break;
            case 2:
                LayerStructrueDataCache.Instance.pointBox.transform.localScale = new Vector3(LayerStructrueDataCache.Instance.pointBox.transform.localScale.x, LayerStructrueDataCache.Instance.pointBox.transform.localScale.y, float.Parse(EidtVaule.Instance.EidtInput.text));
                Debug.Log("点击的值" + value);
                break;
        }
                       
       
    }
}
