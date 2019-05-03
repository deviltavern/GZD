using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneHistoryPage : MainScenePage {

    public HistoryViewport hviewPort;


    public override void setParameter()
    {
        base.setParameter();

        hviewPort = this.transform.Find("Viewport").GetComponent<HistoryViewport>();
    }



}
