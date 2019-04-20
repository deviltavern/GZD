using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainScenePage : PageBase {
 

    public static Dictionary<string, PageBase> stackDic = new Dictionary<string, PageBase>();

    public override void setParameter()
    {

        dic = stackDic;
        initPosition = new Vector3(200, 70);
    }
}
