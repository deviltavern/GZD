using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileButton : ButtonEventBase,IObviewer {


    private List<IViewer> viewList = new List<IViewer>();
    public string path;
    public string textValue;

    public void init(string _path, string _textValue)
    {
        this.path = _path;
        this.textValue = _textValue;
        addViewer(RobotProcedureAnalyser.Instance);

        
    }



    public override void onClickButton()
    {
        ViewInfo info = new ViewInfo();
        info.code = ViewerInfoCoder.clickFileBtn;

        info.arg1 = this.path;

        broadCast(info);


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
