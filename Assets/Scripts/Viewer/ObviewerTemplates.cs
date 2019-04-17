using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObviewerTemplates : MonoBehaviour,IObviewer {

    public List<IViewer> viewList = new List<IViewer>();

    public void addViewer(IViewer view)
    {
        viewList.Add(view);
    }

    public void deleteViewer(IViewer view)
    {
        viewList.Add(view);
    }

    public void broadCast(ViewInfo info)
    {
        foreach (IViewer view in viewList)
        {
            view.update(info);
        }


    }
}
