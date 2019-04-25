using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardViewBaseEX3 :PageBase {

    public static Dictionary<string, PageBase> stackDIc = new Dictionary<string, PageBase>();
    public override void setParameter()
    {
        this.dic = stackDIc;
        initPosition = new Vector3(323, 0);
    }
}
