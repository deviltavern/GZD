using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISaver : UIBase {


    public Button saveBtn;
    public Button save2File;
    public static int stepIndex;
    public static Dictionary<int, GameObject> pointDic = new Dictionary<int, GameObject>();
    void Awake()
    {                                      
      
            saveBtn = this.transform.Find("saveBtn").GetComponent<Button>();
            save2File = this.transform.Find("save2File").GetComponent<Button>();
            saveBtn.onClick.AddListener(onClickSaveStepBtn);
            save2File.onClick.AddListener(onClickSaveBtn);
    }
    public void onClickSaveBtn()
    {
         StepInfoCatcher.Instance.save();
    }

    public void onClickSaveStepBtn()
    {

      

    }

    public static StepInfo saveNewStep()
    {
        StepInfo info = new StepInfo();
        info.index = stepIndex + "";
        
        foreach (int key in pointDic.Keys)
        {
            Debug.Log(key + "：" + pointDic[key].transform.eulerAngles);
            switch (key)
            {
                case 1:
                    info.p1_x = pointDic[key].transform.eulerAngles.x;
                    info.p1_y = pointDic[key].transform.eulerAngles.y;
                    info.p1_z = pointDic[key].transform.eulerAngles.z;
                    break;
                case 2:
                    info.p2_x = pointDic[key].transform.eulerAngles.x;
                    info.p2_y = pointDic[key].transform.eulerAngles.y;
                    info.p2_z = pointDic[key].transform.eulerAngles.z;
                    break;

                case 3:
                    info.p3_x = pointDic[key].transform.eulerAngles.x;
                    info.p3_y = pointDic[key].transform.eulerAngles.y;
                    info.p3_z = pointDic[key].transform.eulerAngles.z;
                    break;

                default:

                    break;
            }


        }


        return info;
    
    
    }


    public void onClickBtn()
    {
        StepInfo info = new StepInfo();
        info.index = stepIndex + "";

        foreach (int key in pointDic.Keys)
        {
            Debug.Log(key + "：" + pointDic[key].transform.eulerAngles);
            switch (key)
            {
                case 1:
                    info.p1_x = pointDic[key].transform.eulerAngles.x;
                    info.p1_y = pointDic[key].transform.eulerAngles.y;
                    info.p1_z = pointDic[key].transform.eulerAngles.z;
                    break;
                case 2:
                    info.p2_x = pointDic[key].transform.eulerAngles.x;
                    info.p2_y = pointDic[key].transform.eulerAngles.y;
                    info.p2_z = pointDic[key].transform.eulerAngles.z;
                    break;

                case 3:
                    info.p3_x = pointDic[key].transform.eulerAngles.x;
                    info.p3_y = pointDic[key].transform.eulerAngles.y;
                    info.p3_z = pointDic[key].transform.eulerAngles.z;
                    break;

                default:

                    break;
            }


        }
        stepIndex++;

        StepInfoCatcher.Instance.addStep(info, StepType.robotsAnimation);

    }
}
