using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAMovement : RobotsMovement {
   
    
    public RobotAMovement(StepInfoDispose _dispose, StepInfo info, float _theChangeDistance, float _speed)    
    {
         this.stepInfoDispose = _dispose;
         this.stepInfo = info;
         this.theChangeDistance = _theChangeDistance;
         this.speed = _speed;

     
     
     }
    float d1;
    float d2;
    float d3;
    float d4;
    float d5;
    float d6;

    Quaternion aimRotate;
    public override void doSomthing()
    {

        for (int i = 0; i < RobotA.Instance.axleDic.Count; i++)
        {
            aimRotate = Quaternion.Euler(StepInfo.getEuler(i+1,stepInfo));
            switch (i)
            {
                case 0:


                    RobotA.Instance.axleDic[AxleName.J1].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J1].transform.localRotation, aimRotate, Time.deltaTime * speed);
                    d1 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles, stepInfo.toP1Euler());
                   
                    break;

                case 1:

                   // RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles = Vector3.Lerp(RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles, stepInfo.toP2Euler(), Time.deltaTime);
                    RobotA.Instance.axleDic[AxleName.J2].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J2].transform.localRotation, aimRotate, Time.deltaTime * speed);
                    d2 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles, stepInfo.toP2Euler());
                    break;

                case 2:
                    RobotA.Instance.axleDic[AxleName.J3].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J3]
                        .transform.localRotation, aimRotate, Time.deltaTime * speed);

                   // RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles = Vector3.Lerp(RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles, stepInfo.toP3Euler(), Time.deltaTime);
                    d3 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles, stepInfo.toP3Euler());
                    break;
                case 3:

                    RobotA.Instance.axleDic[AxleName.J4].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J4]
                        .transform.localRotation, aimRotate, Time.deltaTime * speed);
                   // RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles = Vector3.Lerp(RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles, stepInfo.toP4Euler(), Time.deltaTime);
                    d4 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles, stepInfo.toP4Euler());
                    break;
                case 4:

                   // RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles = Vector3.Lerp(RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles, stepInfo.toP5Euler(), Time.deltaTime);
                    RobotA.Instance.axleDic[AxleName.J5].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J5]
                        .transform.localRotation, aimRotate, Time.deltaTime * speed);
                    d5 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles, stepInfo.toP5Euler());
                    break;

                case 5:
                    RobotA.Instance.axleDic[AxleName.J6].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J6]
                        .transform.localRotation, aimRotate, Time.deltaTime * speed);
                   // RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles = Vector3.Lerp(RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles, stepInfo.toP6Euler(), Time.deltaTime);

                    d6 = Vector3.Distance(RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles, stepInfo.toP6Euler());
                    break;

                default:

                    break;
            }
          
            

        }

      //  Debug.Log(d1 + "--" + d2 + "--" + d3 + "--" + d4 + "--" + d5 + "--" + d6 + "--");
    //  float d1 = Vector3.Distance(Robots.Instance.point_1.transform.eulerAngles, stepInfo.toP1Euler());
    //  float d2 = Vector3.Distance(Robots.Instance.point_2.transform.eulerAngles, stepInfo.toP2Euler());
    //  float d3 = Vector3.Distance(Robots.Instance.point_3.transform.eulerAngles, stepInfo.toP3Euler());
    //
    //
     if ((d1 < theChangeDistance || Mathf.Abs(d1 - 360) < theChangeDistance) && (d2 < theChangeDistance || Mathf.Abs(d2 - 360) < theChangeDistance)

         && (d3 < theChangeDistance || Mathf.Abs(d3 - 360) < theChangeDistance) 
         && (d4 < theChangeDistance || Mathf.Abs(d4 - 360) < theChangeDistance)
         && (d5 < theChangeDistance || Mathf.Abs(d5 - 360) < theChangeDistance) 
         && (d6 < theChangeDistance || Mathf.Abs(d6 - 360) < theChangeDistance))
     {
   
         stepInfoDispose.strategy = null; 
         stepInfoDispose.index++;
   
   
     }


    }
}
