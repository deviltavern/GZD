using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepInfoForAxleDispose : Dispose
{


    public static StepInfo getStepInfoByStepInfoForAxle(AxleStepInfo info)
    {

        StepInfo m_info = new StepInfo();


        return m_info;
    
    
    }

    void Start()
    {
        insNewAxleMovementStrategy(CommonData.stepInfoList);
    }


    void Update()
    {
        if (workStrategy != null)
        {
            workStrategy.doSomthing();
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            insNewAxleMovementStrategy(RobotProcedureAnalyser.stepInfoList);
        }
        
    }

    public void insNewAxleMovementStrategy(List<AxleStepInfo> dataList)
    {
        RobotAAnimationMovementStrategy insStrategy = new RobotAAnimationMovementStrategy(dataList,this);
        this.workStrategy = insStrategy;
            
    }


}
