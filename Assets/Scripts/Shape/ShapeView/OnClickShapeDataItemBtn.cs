using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickShapeDataItemBtn : ButtonEventBase,IObviewer {

    public string data { get; set; }
    public Transform parent;

    public static List<IViewer> viewList = new List<IViewer>();
    public static List<GameObject> gList = new List<GameObject>();
    public override void onClickButton()
    {
        foreach (GameObject g in gList)
        {
            Destroy(g);
        }
        gList.Clear();
        string[] dataArray = data.Split('&');
       
        foreach (string key in dataArray)
        {

            if (key == "")
                continue;
            ShapeItemData sd = JsonUtility.FromJson<ShapeItemData>(key);
            GameObject G =  GameObject.Instantiate(ResourcesManager.prefabDic[ResName.shapeItem], parent);
            gList.Add(G);
            G.transform.localPosition = sd.getVector3();

        }

        ViewInfo info = new ViewInfo();
        info.code = 1;
        info.arg1 = data;
        broadCast(info);
        
      


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
