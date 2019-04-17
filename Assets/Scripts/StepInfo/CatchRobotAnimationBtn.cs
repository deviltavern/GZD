using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchRobotAnimationBtn : StepInfoEvent {


    public static int stepIndex;


    public override void onClickBtn()
    {
        StepInfo info = new StepInfo();
        info.index = stepIndex + "";

        foreach (string key in RobotA.Instance.axleDic.Keys)
        {
            Debug.Log(key + "：" + RobotA.Instance.axleDic[key].transform.eulerAngles);
            switch (key)
            {
                case AxleName.J1:
                    info.p1_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p1_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p1_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break;
                case AxleName.J2:
                    info.p2_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p2_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p2_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break;

                case AxleName.J3:
                    info.p3_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p3_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p3_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break;
                case AxleName.J4:
                    info.p4_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p4_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p4_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break;
                case AxleName.J5:
                    info.p5_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p5_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p5_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break;
                case AxleName.J6:
                    info.p6_x = RobotA.Instance.axleDic[key].transform.localEulerAngles.x;
                    info.p6_y = RobotA.Instance.axleDic[key].transform.localEulerAngles.y;
                    info.p6_z = RobotA.Instance.axleDic[key].transform.localEulerAngles.z;
                    break; 
                default:

                    break;
            }


        }
        stepIndex++;
        StepInfoCatcher.Instance.addStep(info, StepType.robotsAnimation);

    }
}
