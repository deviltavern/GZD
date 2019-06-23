using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StrategyTemplatesEX :Strategy {

    public StrategyMaster master;

    public StrategyTemplatesEX(StrategyMaster _master)
    {
        this.master = _master;
        this.master.addStrategy(this);
    
    }

    public override void doSomthing()
    {

        
     
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }

    public override void onEnd()
    {
        master.deleteStrategy(this);
    }
}
