using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxleStepMoveStrategy : MovementStrategy {


  
    public AxleStepInfo info { get; set; }

    public float speed;
    public Vector3 onTimeJ1;
    public Vector3 onTimeJ2;
    public Vector3 onTimeJ3;
    public Vector3 onTimeJ4;
    public Vector3 onTimeJ5;
    public Vector3 onTimeJ6;
    public int stepIndex { get; set; }

    public Quaternion aimRoJ1;
    public Quaternion aimRoJ2;
    public Quaternion aimRoJ3;
    public Quaternion aimRoJ4;
    public Quaternion aimRoJ5;
    public Quaternion aimRoJ6;

    public Vector3 aimRoEulerJ1;
    public Vector3 aimRoEulerJ2;
    public Vector3 aimRoEulerJ3;
    public Vector3 aimRoEulerJ4;
    public Vector3 aimRoEulerJ5;
    public Vector3 aimRoEulerJ6;

    public AxleStepMoveStrategy(MovementStrategy _parent, AxleStepInfo _info,RobotA role)
    
        :base(_parent)
    {

        
        this.info = _info;
        Debug.Log(info.J1 + "................");


        aimRoEulerJ1 = new Vector3(RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.x, info.J1, RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles.z);
        aimRoEulerJ2 = new Vector3(RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles.x, RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles.y, info.J2);
        aimRoEulerJ3 = new Vector3(RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles.x, RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles.y, info.J3);
        aimRoEulerJ4 = new Vector3(info.J4, RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles.y, RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles.z);
        aimRoEulerJ5 = new Vector3(RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles.x, RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles.y, info.J5);
        aimRoEulerJ6 = new Vector3(info.J6, RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles.y, RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles.z);

        aimRoJ1 = Quaternion.Euler(aimRoEulerJ1);
        aimRoJ2 = Quaternion.Euler(aimRoEulerJ2);
        aimRoJ3 = Quaternion.Euler(aimRoEulerJ3);
        aimRoJ4 = Quaternion.Euler(aimRoEulerJ4);
        aimRoJ5 = Quaternion.Euler(aimRoEulerJ5);
        aimRoJ6 = Quaternion.Euler(aimRoEulerJ6);
        speed = 10;
    }
    public void catchAxleStatus()
    {
        onTimeJ1 = RobotA.Instance.axleDic[AxleName.J1].transform.localEulerAngles;
        onTimeJ2 = RobotA.Instance.axleDic[AxleName.J2].transform.localEulerAngles;
        onTimeJ3 = RobotA.Instance.axleDic[AxleName.J3].transform.localEulerAngles;
        onTimeJ4 = RobotA.Instance.axleDic[AxleName.J4].transform.localEulerAngles;
        onTimeJ5 = RobotA.Instance.axleDic[AxleName.J5].transform.localEulerAngles;
        onTimeJ6 = RobotA.Instance.axleDic[AxleName.J6].transform.localEulerAngles;

    
    }

    public bool nextStepContition(Vector3 aimRo,Vector3 onTimeRo)
    {
        if (Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)) < 1 || Mathf.Abs((Mathf.Abs(Vector3.Distance(aimRo, onTimeRo)) - 360)) < 1)
        {

            stepIndex++;
            return true;
        }
        else {
            return false;
        }
    
        
    }
    public override void doSomthing()
    {
        catchAxleStatus();

    //    switch (stepIndex) { 
    //    
    //        case 0:
    //            RobotA.axleDic[AxleName.J1].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J1].transform.localRotation, aimRoJ1, Time.deltaTime * speed);
    //            nextStepContition(aimRoEulerJ1, onTimeJ1);
    //            
    //            break;
    //
    //        case 1:
    //              RobotA.axleDic[AxleName.J2].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J2].transform.localRotation, aimRoJ2, Time.deltaTime * speed);
    //              nextStepContition(aimRoEulerJ2, onTimeJ2);
    //            break;
    //
    //        case 2:
    //
    //             RobotA.axleDic[AxleName.J3].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J3].transform.localRotation, aimRoJ3, Time.deltaTime * speed);
    //             nextStepContition(aimRoEulerJ3, onTimeJ3);
    //            break;
    //
    //        case 3:
    //
    //              RobotA.axleDic[AxleName.J4].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J4].transform.localRotation, aimRoJ4, Time.deltaTime * speed);
    //              nextStepContition(aimRoEulerJ4, onTimeJ4);
    //            break;
    //
    //        case 4:
    //              RobotA.axleDic[AxleName.J5].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J5].transform.localRotation, aimRoJ5, Time.deltaTime * speed);
    //              nextStepContition(aimRoEulerJ5, onTimeJ5);
    //            break;
    //
    //        case 5:
    //              RobotA.axleDic[AxleName.J6].transform.localRotation = Quaternion.LerpUnclamped(RobotA.axleDic[AxleName.J6].transform.localRotation, aimRoJ6, Time.deltaTime * speed);
    //              nextStepContition(aimRoEulerJ6, onTimeJ6);
    //            Debug.Log("执行完第一个数据的策略，填充下一个策略执行！");
    //            parent.insNextStrategy();
    //            
    //            break;
    //    
    //    }

        RobotA.Instance.axleDic[AxleName.J1].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J1].transform.localRotation, aimRoJ1, Time.deltaTime * speed);
        RobotA.Instance.axleDic[AxleName.J2].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J2].transform.localRotation, aimRoJ2, Time.deltaTime * speed);
        RobotA.Instance.axleDic[AxleName.J3].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J3].transform.localRotation, aimRoJ3, Time.deltaTime * speed);
        RobotA.Instance.axleDic[AxleName.J4].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J4].transform.localRotation, aimRoJ4, Time.deltaTime * speed);
        RobotA.Instance.axleDic[AxleName.J5].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J5].transform.localRotation, aimRoJ5, Time.deltaTime * speed);
                                                                                                     
        RobotA.Instance.axleDic[AxleName.J6].transform.localRotation = Quaternion.LerpUnclamped(RobotA.Instance.axleDic[AxleName.J6].transform.localRotation, aimRoJ6, Time.deltaTime * speed);
        switch (stepIndex) { 
         
             case 0:
                
                 nextStepContition(aimRoEulerJ1, onTimeJ1);
                 
                 break;
     
             case 1:
                  
                   nextStepContition(aimRoEulerJ2, onTimeJ2);
                 break;
     
             case 2:
     
                 
                  nextStepContition(aimRoEulerJ3, onTimeJ3);
                 break;
     
             case 3:
     
                 
                   nextStepContition(aimRoEulerJ4, onTimeJ4);
                 break;
     
             case 4:
                   
                   nextStepContition(aimRoEulerJ5, onTimeJ5);
                 break;
     
             case 5:
                  
                   nextStepContition(aimRoEulerJ6, onTimeJ6);
                 Debug.Log("执行完第一个数据的策略，填充下一个策略执行！");
                 parent.insNextStrategy();
                 
                 break;
         
         }

    }

    public override void waitting()
    {
        
    }
}
