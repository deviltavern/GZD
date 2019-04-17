using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseChestStrategy : StepStrategyTemplates {

    public ReleaseChestStrategy(StepInfoDispose _dispose)
    {
        this.stepInfoDispose = _dispose;
    }


    float frameTime = 0;
    public override void doSomthing()
    {

        
        if (frameTime == 0)
        {
            this.stepInfoDispose.releaseChestEvent();
        }
        frameTime += Time.deltaTime;

        if (frameTime > 1)
        {
            endStepStrategy();

        }

        

    }
}
