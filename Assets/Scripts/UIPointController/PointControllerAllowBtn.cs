using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PointControllerAllowBtn :MonoBehaviour{

     public string controllerID;
     Button button;

     public static UIPointController preController;
    public virtual void Awake()
    {

        button = this.transform.GetComponent<Button>();

        button.onClick.AddListener(onClickThisButton);

        button.onClick.AddListener(buttonEvent2ChangeAxleItemColor);



    }

    public KeyCode code;
    public void Update()
    {

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKeyDown(code))
            {
                Debug.Log("点击了快捷键！");

                onClickThisButton();
                buttonEvent2ChangeAxleItemColor();
            }
        }



    }

    public virtual void onClickThisButton() {

        PointControllerAllowBtn.preController = UIPointController.PointControllerDic[this.controllerID].onClickAllowBtn(this.controllerID);
        
    }

    public void buttonEvent2ChangeAxleItemColor()
    {

        AxleItem.onPointThisChangeItem(this.controllerID);
    
    
    }
}
