using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardViewBaseEX1 : PageBase
{

    public static Dictionary<string, PageBase> stackDIc = new Dictionary<string, PageBase>();
    public override void setParameter()
    {
        this.dic = stackDIc;
        initPosition = new Vector3(323, 0);
    }
}
