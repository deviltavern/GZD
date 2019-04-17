using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrashCatcherBtn : MonoBehaviour {


    public Button btn;


    void Awake()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(onClickBtn);
    }


    void onClickBtn()
    {
        CrashCatcher.Instance.InsCrashItem(RobotA.hand,new Vector3(0,-1,0));

        
    }


}
