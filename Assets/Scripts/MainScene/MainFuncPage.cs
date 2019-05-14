using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFuncPage : MonoBehaviour {

    public RectTransform  backGround;
    public Button newProject;
    public Button history;
    public Button custom;
    public Button simulink;
    public static MainFuncPage Instance;
    private void Awake()
    {
        backGround = this.transform.Find("backGround").GetComponent<RectTransform>();
        newProject = backGround.transform.Find("newProject").GetComponent<Button>();
        history = backGround.transform.Find("history").GetComponent<Button>();
        custom = backGround.transform.Find("custom").GetComponent<Button>();    
        simulink = backGround.transform.Find("simulink").GetComponent<Button>();


        newProject.onClick.AddListener(onClickNewProject);
        history.onClick.AddListener(onClickHistory);
        custom.onClick.AddListener(onClickCustom);
        simulink.onClick.AddListener(onClickSimulink);
        Instance = this;

    }

    private void Start() {
        foreach (string key in MainScenePage.stackDic.Keys)
        {

        }
    }
    public Dropdown dType;
    public Dropdown dLabel;
    public Dropdown Box_Type;
    public Dropdown Baseboard_Type;
    public void onClickNewProject()
    {

        MainScenePage.stackDic[MainSceneResName.newProjectpageName].showPage();


        MainSceneNewProjectPage page = (MainSceneNewProjectPage)MainScenePage.stackDic[MainSceneResName.newProjectpageName];
        //找到下拉框资源
        dLabel = page.produceBoard.labelDropDown;
        dType = page.socektBoard.dropDown;
        //在存列表的字典中，找到在config文件中的“下拉框”子节点对应列表；
        ListBaseX type_data = ConfigFile.dataDic["cs_kind"];
        ListBaseX label_data = ConfigFile.dataDic["cp_label"];

        //清除option，添加option
        //dLabel.options.Clear();
        //dLabel.AddOptions(label_data.getList());

        dType.options.Clear();
        dType.AddOptions(type_data.getList());

        Debug.Log("123");

    }

    public void onClickHistory()
    {

       

        MainSceneHistoryPage hisPage = (MainSceneHistoryPage)MainScenePage.stackDic[MainSceneResName.historypageName];

        hisPage.showPage();
        hisPage.hviewPort.updateViewportInfo();

    }

    public void onClickCustom()
    {
         MainScenePage.stackDic[MainSceneResName.custompageName].showPage();
        //****************
        MainSceneCustomPage page = (MainSceneCustomPage)MainScenePage.stackDic["MainSceneCustomPage"];
      
        //找到下拉框资源
        Box_Type = page.box_Dropdown;
        Baseboard_Type = page.baseboard_Dropdown;
        //在存列表的字典中，找到在config文件中的“下拉框”子节点对应列表；

        List<string> Box_tempList = new List<string>();
        List<string> Baseboard_tempList = new List<string>();
        Box_tempList.Add("请选择Box");
        Baseboard_tempList.Add("请选择Baseboard");


        foreach (BoxData element in BoxData.dic.Values)
        {
            Box_tempList.Add(element.id);
        }
        foreach (BaseboardData element in BaseboardData.Baseboard_dic.Values)
        {
            Baseboard_tempList.Add(element.id);
        }
       
        //清除option，添加option
        Box_Type.options.Clear();
        Box_Type.AddOptions(Box_tempList);
        Baseboard_Type.options.Clear();
        Baseboard_Type.AddOptions(Baseboard_tempList);


        Debug.Log("9999999999999999999999999999999");



    }

    public void onClickSimulink()
    {
        MainScenePage.stackDic[MainSceneResName.simulinkpageName].showPage();

    }
}
