using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulinkButton : ButtonEventBase {
    public string data { get; set; }
    public Transform parent;

    public static List<IViewer> viewList = new List<IViewer>();
    public static List<GameObject> gList = new List<GameObject>();
    public override void onClickButton()
    {
        //data = DataCah





    }
    public static void addViewers(IViewer view)
    {
        viewList.Add(view);
    }

    public void addViewer(IViewer view)
    {
        viewList.Add(view);
    }

    public void deleteViewer(IViewer view)
    {
        viewList.Remove(view);

    }

    public void broadCast(ViewInfo info)
    {
        foreach (IViewer view in viewList)
        {
            view.update(info);
        }
    }
}
