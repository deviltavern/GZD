using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAAnimationMovementStrategy : MovementStrategy {


    public static List<AxleStepInfo> stepInfoList = new List<AxleStepInfo>();
    public static int doStep = 0;
    public Dispose workParent;
    public AxleStepInfo getTopAxleStepInfo()
    {
        if (doStep >= stepInfoList.Count)
        {
            workParent.workStrategy = null;
            Debug.Log("返回空对象！");

            return null;
        }
        else
        {
            Debug.Log("返回非空对象！");
            AxleStepInfo info = stepInfoList[doStep];

            doStep++;

            return info;
        }
        
       
    
    }
    int index = 0;
    public override void insNextStrategy()
    {
        Debug.Log("生成機器人运动策略！");
        AxleStepInfo info = getTopAxleStepInfo();

        if (info != null)
        {
            index++;
            workStrategy = new AxleStepMoveStrategy(this, info, RobotA.Instance);
            TimeSchedule.Instance.setText(index + "");

        }

      

    }
    public RobotAAnimationMovementStrategy(List<AxleStepInfo> _stepInfoList,Dispose _dispose)  
    {
        this.workParent = _dispose;
        stepInfoList = _stepInfoList;
        Debug.Log(stepInfoList.Count + "信息长度~");

        insNextStrategy();
    
    }

    public override void doSomthing()
    {
        base.doSomthing();
    
    
    
    }
    
  
    
}
