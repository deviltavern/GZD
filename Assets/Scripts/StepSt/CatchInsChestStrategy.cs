using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchInsChestStrategy : StepStrategyTemplates {


    public CatchInsChestStrategy(StepInfoDispose _dispose)
    {
        this.stepInfoDispose = _dispose;
    }


    public override void doSomthing()
    {



        stepInfoDispose.catchChestEvent();

        stepInfoDispose.strategy = null;
        stepInfoDispose.index++;



    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }
}
