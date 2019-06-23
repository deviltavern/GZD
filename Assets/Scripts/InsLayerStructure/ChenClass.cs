using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChenClass : MonoBehaviour,IObviewer
{
    public int BtnStatus;
    public ViewInfo info;
   List<IViewer> viewList = new List<IViewer>();
       
    // Use this for initialization
    void Start()
    {
        new InputStrategy_Edit(LayerStructureInputManager.Instance);
      
        EidtVaule.Instance.OkBtn.onClick.AddListener(OnClickEidtBtn);

        //添加被观察者
        addViewer(InputStrategy_Edit.instance);
        BtnStatus = 0;
    }

    

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickEidtBtn()
    {

        BtnStatus = 1;
        info = new ViewInfo();
        info.arg1 = BtnStatus+"" ;
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
        foreach (IViewer view in viewList) {

          
            
            view.update(info);
        
        }

    }
}
