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

    public void onClickNewProject()
    {

        MainScenePage.stackDic[MainSceneResName.newProjectpageName].showPage();

    }

    public void onClickHistory()
    {

        MainScenePage.stackDic[MainSceneResName.historypageName].showPage();

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
