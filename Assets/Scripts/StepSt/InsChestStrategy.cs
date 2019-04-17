using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsChestStrategy : StepStrategyTemplates {
    public InsChestStrategy(StepInfoDispose _dispose)
    {
        this.stepInfoDispose = _dispose;
    }

    public override void doSomthing()
    {

        stepInfoDispose.insChest();

        endStepStrategy();
        Debug.Log("执行生成Chest的策略");



    }


}
