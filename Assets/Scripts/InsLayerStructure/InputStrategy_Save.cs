using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_Save : Strategy {
    public override void doSomthing()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {

            if (Input.GetKeyDown(KeyCode.S))
            {

                LayerStructrueDataCache.Instance.insJsonData("layer");
            }
        }
    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }

  
}
