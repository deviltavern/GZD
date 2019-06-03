using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepStrategyTemplates : Strategy {

    public Robots robot { get; set; }

    public StepInfoDispose stepInfoDispose { get; set; }

    public void endStepStrategy() {

        stepInfoDispose.index++;
        stepInfoDispose.strategy = null;
    }
    public override void doSomthing()
    {
        throw new System.NotImplementedException();
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }
}
