using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Delete : Strategy
{


    StrategyMaster master;

    public InputStrategy_Delete(StrategyMaster master)
    {
        this.master = master;



    }

    public override void doSomthing()
    {

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            master.endStrategy();
            LayerStructrueDataCache.Instance.onDestroyPointBox();
           
            Debug.Log("删除！");
        }
       
    }

    public override void onEnd()
    {
       
    }

    public override void waitting()
    {
        
    }
}
