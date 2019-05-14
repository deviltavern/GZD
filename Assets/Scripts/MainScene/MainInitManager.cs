using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainInitManager : MonoBehaviour, IObviewer
{
    public Dropdown Baseboard_Type;
    /// <summary>
    /// 存储观察者
    /// </summary>
    List<IViewer> viewList = new List<IViewer>();
	// Use this for initialization
	void Start () {

        addViewer(CustomController.Instance);

        StartCoroutine(delayInit());
        
	}
    IEnumerator delayInit(){
        yield return new WaitForSeconds(Time.deltaTime);

        ConfigFile.Instance.LoadXml();

        List<string> Baseboard_tempList = new List<string>();

        if (DataCatche.onRebackFromInsBaseBoard != null && DataCatche.onRebackFromInsBaseBoard!=-1 )
        {
            Debug.Log(DataCatche.onRebackFromInsBaseBoard);
            //从存有baseboard的字典里面获取id对应属性

            foreach (BaseboardData element in BaseboardData.Baseboard_dic.Values)
            {
                Baseboard_tempList.Add(element.id);
            }

            BaseboardData reData ;
            int value = getDdValue(DataCatche.onRebackFromInsBaseBoard + "", Baseboard_tempList, out reData);
            //value 是返回的option的value“0，1，2，3”
            //reData是字典中baseBoard_id对应的BaseboardData

            ViewInfo info = new ViewInfo();
            info.arg1 = value+"";
            info.arg3 = reData;


            broadCast(info);

        }
    }

    public static int getDdValue(string baseBoard_id, List<string> opTions, out BaseboardData data)
    {

        data = BaseboardData.Baseboard_dic[baseBoard_id];

        for(int i =0;i<opTions.Count;i++)
        {
          if (opTions[i] == baseBoard_id)
            {
                return i;
            }
        }
       
        return 0;

        
    }
 
    public void onRebackOption(BaseboardData _reData, int _value)
    {

        MainSceneCustomPage page = (MainSceneCustomPage)MainScenePage.stackDic["MainSceneCustomPage"];

        //找到下拉框资源

        Baseboard_Type = page.baseboard_Dropdown;
        //在存列表的字典中，找到在config文件中的“下拉框”子节点对应列表；

        List<string> Baseboard_tempList = new List<string>();
        Baseboard_Type.value = _value;


     
     

   


       




    }
	// Update is called once per frame
	void Update () {
		
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
