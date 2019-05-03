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


    }

    private void Start() {
        foreach (string key in MainScenePage.stackDic.Keys)
        {
            print(key);
        }
    }
    public Dropdown dType;
    public Dropdown dLabel;
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
        dLabel.options.Clear();
        dLabel.AddOptions(label_data.getList());

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
    }

    public void onClickSimulink()
    {
        MainScenePage.stackDic[MainSceneResName.simulinkpageName].showPage();

    }
}
